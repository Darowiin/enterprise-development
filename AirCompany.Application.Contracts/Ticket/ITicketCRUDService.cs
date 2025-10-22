using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;

namespace AirCompany.Application.Contracts.Ticket;

/// <summary>
/// Ticket service interface for performing CRUD operations with related entities.
/// </summary>
public interface ITicketCrudService : IApplicationCrudService<TicketDto, TicketCreateUpdateDto, int>
{
    /// <summary>
    /// Retrieves the <see cref="PassengerDto"/> associated with the specified ticket.
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <returns>The passenger associated with the ticket.</returns>
    public Task<PassengerDto> GetPassenger(int ticketId);

    /// <summary>
    /// Retrieves the <see cref="FlightDto"/> associated with the specified ticket.
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <returns>The flight associated with the ticket.</returns>
    public Task<FlightDto> GetFlight(int ticketId);
}