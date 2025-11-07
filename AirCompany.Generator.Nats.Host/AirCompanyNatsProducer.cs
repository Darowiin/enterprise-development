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
    public async Task SendAsync(IList<TicketCreateUpdateDto> batch)
    {
        try
        {
            await connection.ConnectAsync();
            var context = connection.CreateJetStreamContext();
            var stream = context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_subjectName]));
            logger.LogInformation("Establishing a stream {stream} with subject {subject}", _streamName, _subjectName);

            await context.PublishAsync(_subjectName, JsonSerializer.SerializeToUtf8Bytes(batch));
            logger.LogInformation("Sent a batch of {count} contracts to {subject} of {stream}", batch.Count, _subjectName, _streamName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during sending a batch of {count} contracts to {stream}/{subject}", batch.Count, _streamName, _subjectName);
        }
    }
}
