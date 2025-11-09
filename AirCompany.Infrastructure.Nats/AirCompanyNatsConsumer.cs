using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using System.Text.Json;

namespace AirCompany.Infrastructure.Nats;

/// <summary>
/// Background service consuming Ticket contracts from a NATS JetStream subject.
/// </summary>
/// <param name="connection">NATS connection.</param>
/// <param name="scopeFactory">Factory for creating service scopes.</param>
/// <param name="configuration">Application configuration.</param>
/// <param name="logger">Logger for informational and error messages.</param>
public class AirCompanyNatsConsumer(
    INatsConnection connection,
    IServiceScopeFactory scopeFactory,
    IConfiguration configuration,
    ILogger<AirCompanyNatsConsumer> logger
) : BackgroundService
{
    private readonly string _subjectName = configuration.GetSection("Nats")["SubjectName"] ?? throw new KeyNotFoundException("SubjectName section of Nats is missing");

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var msg in connection.SubscribeAsync<byte[]>(_subjectName, cancellationToken: stoppingToken))
        {
            var batchMsg = JsonSerializer.Deserialize<BatchMessage>(msg.Data);
            try
            {
                if (batchMsg is null || batchMsg.Data is null)
                {
                    logger.LogWarning("Received null or malformed batch from {subject}", _subjectName);
                    await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg?.BatchId ?? Guid.Empty, Inserted = 0 });
                    continue;
                }

                using var scope = scopeFactory.CreateScope();
                var ticketService = scope.ServiceProvider.GetRequiredService<ITicketCrudService>();
                var inserted = await ticketService.ReceiveContractList(batchMsg.Data);

                await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg.BatchId, Inserted = inserted });
                logger.LogInformation("Processed batch {batchId}: {inserted}/{count} inserted", batchMsg.BatchId, inserted, batchMsg.Data.Count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing batch {batchId}", batchMsg!.BatchId);
                await SendAck(msg.ReplyTo, new BatchAckResponse { BatchId = batchMsg.BatchId, Inserted = 0 });
            }
        }
    }

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