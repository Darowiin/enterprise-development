using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;
using System.Text.Json;

namespace AirCompany.Validator.Nats;

/// <summary>
/// Background service that validates incoming ticket batches from the raw NATS subject,
/// filters out invalid or duplicate tickets, and publishes valid tickets to the validated subject.
/// </summary>
/// <param name="connection">NATS connection.</param>
/// <param name="scopeFactory">Factory for creating service scopes.</param>
/// <param name="configuration">Application configuration.</param>
/// <param name="logger">Logger for informational and error messages.</param>
public class TicketValidatorService(
    INatsConnection connection,
    IServiceScopeFactory scopeFactory,
    IConfiguration configuration,
    ILogger<TicketValidatorService> logger
) : BackgroundService
{
    
    private readonly string _streamName = configuration.GetSection("Nats")["StreamName"] ?? throw new KeyNotFoundException("StreamName section of Nats is missing");
    private readonly string _rawSubject = configuration.GetSection("Nats")["RawSubject"] ?? throw new KeyNotFoundException("RawSubject section of Nats is missing");
    private readonly string _validatedSubject = configuration.GetSection("Nats")["ValidatedSubject"] ?? throw new KeyNotFoundException("ValidatedSubject section of Nats is missing");

    /// <summary>
    /// Starts the background service and subscribes to the raw NATS subject to receive ticket batches.
    /// </summary>
    /// <param name="stoppingToken">Token to signal service shutdown.</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await connection.ConnectAsync();
        var context = connection.CreateJetStreamContext();
        await context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_validatedSubject]), stoppingToken);

        logger.LogInformation("TicketValidatorService started, subscribing to {subject}", _rawSubject);

        await foreach (var msg in connection.SubscribeAsync<byte[]>(_rawSubject, cancellationToken: stoppingToken))
        {
            _ = ProcessMessageAsync(msg, stoppingToken);
        }
    }

    /// <summary>
    /// Processes a single NATS message containing a batch of tickets.
    /// </summary>
    /// <param name="msg">The raw NATS message containing the batch.</param>
    /// <param name="ct">Cancellation token to stop processing.</param>
    private async Task ProcessMessageAsync(NatsMsg<byte[]> msg, CancellationToken ct)
    {
        BatchMessage? batchMsg;
        try
        {
            batchMsg = JsonSerializer.Deserialize<BatchMessage>(msg.Data);
            if (batchMsg is null || batchMsg.Data is null)
            {
                logger.LogWarning("Malformed batch on {subject}", _rawSubject);
                await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg?.BatchId ?? Guid.Empty });
                return;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to deserialize batch from {subject}", _rawSubject);
            await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = Guid.Empty });
            return;
        }

        try
        {
            using var scope = scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AirCompanyDbContext>();

            var incoming = batchMsg.Data;
            var seatPairs = incoming
             .Select(t => new { t.FlightId, t.SeatNumber })
             .Distinct()
             .ToList();

            var flightIds = seatPairs.Select(p => p.FlightId).Distinct().ToList();
            var passengerIds = incoming.Select(t => t.PassengerId).Distinct().ToList();
            var seatNumbers = seatPairs.Select(p => p.SeatNumber).Distinct().ToList();

            var candidates = await db.Tickets
                .Where(t => flightIds.Contains(t.FlightId) && seatNumbers.Contains(t.SeatNumber))
                .Select(t => new { t.FlightId, t.SeatNumber })
                .ToListAsync(ct);

            var existingSet = new HashSet<string>(candidates.Select(c => $"{c.FlightId}:{c.SeatNumber}"));

            var existingFlights = await db.Flights.Where(f => flightIds.Contains(f.Id)).Select(f => f.Id).ToListAsync(ct);
            var existingPassengers = await db.Passengers.Where(p => passengerIds.Contains(p.Id)).Select(p => p.Id).ToListAsync(ct);

            var flightSet = existingFlights.ToHashSet();
            var passengerSet = existingPassengers.ToHashSet();

            var validated = new List<TicketCreateUpdateDto>();
            foreach (var t in incoming)
            {
                if (!flightSet.Contains(t.FlightId))
                {
                    logger.LogDebug("Drop ticket: flight {FlightId} not found", t.FlightId);
                    continue;
                }
                if (!passengerSet.Contains(t.PassengerId))
                {
                    logger.LogDebug("Drop ticket: passenger {PassengerId} not found", t.PassengerId);
                    continue;
                }

                var key = $"{t.FlightId}:{t.SeatNumber}";
                if (existingSet.Contains(key))
                {
                    logger.LogDebug("Drop ticket: seat already exists {Key}", key);
                    continue;
                }

                existingSet.Add(key);
                validated.Add(t);
            }

            if (validated.Count == 0)
            {
                logger.LogInformation("Batch {batchId} contains 0 valid tickets — replying 0", batchMsg.BatchId);
                await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg.BatchId });
                return;
            }

            var outMsg = new BatchMessage { BatchId = batchMsg.BatchId, Data = validated };
            var payload = JsonSerializer.SerializeToUtf8Bytes(outMsg);

            await connection.PublishAsync(_validatedSubject, payload, replyTo: msg.ReplyTo, cancellationToken: ct);
            logger.LogInformation("Published validated batch {batchId} with {count} tickets to {subject}", batchMsg.BatchId, validated.Count, _validatedSubject);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled error validating batch {batchId}", batchMsg.BatchId);
            await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg.BatchId });
        }
    }

    /// <summary>
    /// Sends acknowledgment back to the producer indicating processing result of the batch.
    /// </summary>
    /// <param name="replyTo">The NATS inbox to send the acknowledgment to.</param>
    /// <param name="ack">The acknowledgment object containing the batch ID and inserted count.</param>
    private async Task SendAck(string? replyTo, BatchAckResponse ack)
    {
        if (string.IsNullOrEmpty(replyTo)) return;

        try
        {
            var payload = JsonSerializer.SerializeToUtf8Bytes(ack);
            await connection.PublishAsync(replyTo, payload);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Failed to send ack to {replyTo}", replyTo);
        }
    }
}
