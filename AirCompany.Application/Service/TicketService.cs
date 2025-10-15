using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Domain;
using AirCompany.Domain.Model;
using MapsterMapper;

namespace AirCompany.Application.Service;

/// <summary>
/// Service that provides CRUD operations for <see cref="Ticket"/> entities.
/// Implements <see cref="ITicketCRUDService"/> for Ticket DTOs.
/// </summary>
public class TicketService(IRepository<Ticket, int> repository, IMapper mapper) : ITicketCRUDService
{
    /// <summary>
    /// Creates a new <see cref="Ticket"/> entity and returns its DTO.
    /// </summary>
    /// <param name="dto">Ticket data for creation.</param>
    /// <returns>The created <see cref="TicketDto"/>.</returns>
    public TicketDto Create(TicketCreateUpdateDto dto)
    {
        var entity = mapper.Map<Ticket>(dto);

        repository.Create(entity);

        return mapper.Map<TicketDto>(entity);
    }

    /// <summary>
    /// Retrieves a <see cref="TicketDto"/> by its ID.
    /// </summary>
    /// <param name="ticketId">The ID of the ticket to retrieve.</param>
    /// <returns>The <see cref="TicketDto"/> corresponding to the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public TicketDto Get(int ticketId)
    {
        var entity = repository.Get(ticketId)
                     ?? throw new KeyNotFoundException($"Entity with ID {ticketId} not found");
        return mapper.Map<TicketDto>(entity);
    }

    /// <summary>
    /// Retrieves all tickets as DTOs.
    /// </summary>
    /// <returns>List of <see cref="TicketDto"/>.</returns>
    public List<TicketDto> GetAll() => mapper.Map<List<TicketDto>>(repository.GetAll());

    /// <summary>
    /// Updates an existing <see cref="Ticket"/> entity.
    /// </summary>
    /// <param name="dto">Updated ticket data.</param>
    /// <param name="ticketId">The ID of the ticket to update.</param>
    /// <returns>The updated <see cref="TicketDto"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public TicketDto Update(TicketCreateUpdateDto dto, int ticketId)
    {
        var entity = repository.Get(ticketId)
                     ?? throw new KeyNotFoundException($"Entity with ID {ticketId} not found");

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<TicketDto>(entity);
    }

    /// <summary>
    /// Deletes a ticket by its ID.
    /// </summary>
    /// <param name="ticketId">The ID of the ticket to delete.</param>
    public void Delete(int ticketId) => repository.Delete(ticketId);

    /// <summary>
    /// Retrieves the passenger associated with a given ticket.
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <returns>The <see cref="PassengerDto"/> linked to the ticket.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the ticket does not exist.</exception>
    public PassengerDto GetPassenger(int ticketId)
    {
        var entity = repository.Get(ticketId)
                    ?? throw new KeyNotFoundException($"Entity with ID {ticketId} not found");

        return mapper.Map<PassengerDto>(entity.Passenger);
    }

    /// <summary>
    /// Retrieves the flight associated with a given ticket.
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <returns>The <see cref="FlightDto"/> linked to the ticket.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the ticket does not exist.</exception>
    public FlightDto GetFlight(int ticketId)
    {
        var entity = repository.Get(ticketId)
                    ?? throw new KeyNotFoundException($"Entity with ID {ticketId} not found");

        return mapper.Map<FlightDto>(entity.Flight);
    }
}