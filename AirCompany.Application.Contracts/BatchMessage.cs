using AirCompany.Application.Contracts.Ticket;

namespace AirCompany.Application.Contracts;

/// <summary>
/// Represents a batch message sent from the producer to the consumer.
/// </summary>
public class BatchMessage
{
    /// <summary>
    /// The unique identifier of the batch.
    /// </summary>
    public Guid BatchId { get; set; }

    /// <summary>
    /// The list of ticket contracts included in the batch.
    /// </summary>
    public List<TicketCreateUpdateDto> Data { get; set; } = null!;
}