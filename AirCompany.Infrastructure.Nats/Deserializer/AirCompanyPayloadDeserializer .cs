using AirCompany.Application.Contracts.Ticket;
using NATS.Client.Core;
using System.Buffers;
using System.Text.Json;

namespace AirCompany.Infrastructure.Nats.Deserializer;

/// <summary>
/// Deserializer for message payload in Nats.
/// </summary>
public class AirCompanyPayloadDeserializer : INatsDeserialize<IList<TicketCreateUpdateDto>>
{
    /// <inheritdoc/>
    public IList<TicketCreateUpdateDto>? Deserialize(in ReadOnlySequence<byte> buffer) =>
        JsonSerializer.Deserialize<IList<TicketCreateUpdateDto>>(buffer.ToArray());
}
