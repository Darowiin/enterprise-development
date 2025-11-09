using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Ticket;

namespace AirCompany.Generator.Service;

/// <summary>
/// Interface of a service responsible for sending messages over the bus.
/// </summary>
public interface IProducerService
{
    /// <summary>
    /// Sends a collection of contracts.
    /// </summary>
    /// <param name="batch">Collection of contracts.</param>
    public Task<BatchAckResponse> SendAsync(IList<TicketCreateUpdateDto> batch);
}