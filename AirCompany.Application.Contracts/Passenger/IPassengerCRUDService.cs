using AirCompany.Application.Contracts.Ticket;

namespace AirCompany.Application.Contracts.Passenger;

/// <summary>
/// Passenger service interface for performing CRUD operations with related entites.
/// </summary>
public interface IPassengerCrudService : IApplicationCrudService<PassengerDto, PassengerCreateUpdateDto, int>
{
    /// <summary>
    /// Retrieves all <see cref="TicketDto"/> instances associated with a specific passenger.
    /// </summary>
    /// <param name="passengerId">The unique identifier of the passenger.</param>
    /// <returns>A list of tickets belonging to the specified passenger.</returns>
    public Task<IList<TicketDto>> GetTickets(int passengerId);
}