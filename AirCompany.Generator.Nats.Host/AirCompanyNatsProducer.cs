using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Generator.Service;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;
using System.Text.Json;

namespace AirCompany.Generator.Nats.Host;

/// <summary>
/// NATS producer service for sending <see cref="TicketCreateUpdateDto"/> contracts to a JetStream subject.
/// </summary>
/// <param name="configuration">Application configuration.</param>
/// <param name="connection">Connection to NATS server.</param>
/// <param name="logger">Logger for information and errors.</param>
public class AirCompanyNatsProducer(
    IConfiguration configuration,
    INatsConnection connection,
    ILogger<AirCompanyNatsProducer> logger
) : IProducerService
{
    private readonly string _streamName = configuration.GetSection("Nats")["StreamName"] ?? throw new KeyNotFoundException("StreamName section of Nats is missing");
    private readonly string _subjectName = configuration.GetSection("Nats")["SubjectName"] ?? throw new KeyNotFoundException("SubjectName section of Nats is missing");

    /// <inheritdoc/>
    public async Task<BatchAckResponse> SendAsync(IList<TicketCreateUpdateDto> batch)
    {
        var batchId = Guid.NewGuid();
        var payload = new
        {
            BatchId = batchId,
            Data = batch
        };
        await connection.ConnectAsync();
        var context = connection.CreateJetStreamContext();
        await context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_subjectName]));

        var replyInbox = $"_INBOX.{Guid.NewGuid():N}";

        var tcs = new TaskCompletionSource<BatchAckResponse>(TaskCreationOptions.RunContinuationsAsynchronously);

        _ = Task.Run(async () =>
        {
            await foreach (var msg in connection.SubscribeAsync<byte[]>(replyInbox))
            {
                try
                {
                    var ack = JsonSerializer.Deserialize<BatchAckResponse>(msg.Data);
                    if (ack is not null && ack.BatchId == batchId)
                    {
                        tcs.TrySetResult(new BatchAckResponse { BatchId = batchId, Inserted = ack.Inserted });
                        break;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Failed to deserialize ack on inbox {inbox}", replyInbox);
                }
            }
        });

        await connection.PublishAsync(_subjectName, JsonSerializer.SerializeToUtf8Bytes(payload), replyTo: replyInbox);
        logger.LogInformation("Sent batch {batchId} ({count} items) to {subject}", batchId, batch.Count, _subjectName);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        var completed = await Task.WhenAny(tcs.Task, Task.Delay(Timeout.Infinite, cts.Token));

        if (completed != tcs.Task)
        {
            logger.LogWarning("No ACK received for batch {batchId} within timeout", batchId);
            return new BatchAckResponse { BatchId = batchId, Inserted = 0 };
        }

        return await tcs.Task;
    }
}