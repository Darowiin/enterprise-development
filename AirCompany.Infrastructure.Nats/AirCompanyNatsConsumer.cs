using AirCompany.Application.Contracts.Ticket;
using AirCompany.Infrastructure.Nats.Deserializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;

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
    private readonly string _streamName = configuration.GetSection("Nats")["StreamName"] ?? throw new KeyNotFoundException("StreamName section of Nats is missing");
    private readonly string _subjectName = configuration.GetSection("Nats")["SubjectName"] ?? throw new KeyNotFoundException("SubjectName section of Nats is missing");

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await connection.ConnectAsync();
            var context = connection.CreateJetStreamContext();
            var consumer = await context.CreateConsumerAsync
                (
                _streamName,
                new ConsumerConfig
                {
                    DeliverPolicy = ConsumerConfigDeliverPolicy.All,
                    AckPolicy = ConsumerConfigAckPolicy.Explicit,
                    MaxDeliver = 5,
                    FilterSubject = _subjectName
                },
                stoppingToken
                );

            logger.LogInformation("Consumer created for stream {stream} and subject {subject}", _streamName, _subjectName);

            while (!stoppingToken.IsCancellationRequested)
            {
                await foreach (var message in consumer.ConsumeAsync(new AirCompanyPayloadDeserializer(), cancellationToken: stoppingToken))
                {
                    if (message.Data is null)
                    {
                        logger.LogWarning("Received null message on {subject}", _subjectName);
                        continue;
                    }

                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            using var scope = scopeFactory.CreateScope();
                            var ticketService = scope.ServiceProvider.GetRequiredService<ITicketCrudService>();
                            await ticketService.ReceiveContractList(message.Data);
                            logger.LogInformation("Successfully processed message batch from {subject}", _subjectName);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Failed processing message batch from {subject}", _subjectName);
                        }
                    }, stoppingToken);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during receiving contracts from {stream}/{subect}", _subjectName, _subjectName);
        }
    }
}