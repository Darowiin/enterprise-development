using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Domain;
using AirCompany.Domain.Model;
using MapsterMapper;

namespace AirCompany.Application.Service;

/// <summary>
/// Service that provides CRUD operations for <see cref="Passenger"/> entities.
/// Implements <see cref="IPassengerCrudService"/> for Passenger DTOs.
/// </summary>
public class PassengerService(IRepository<Passenger, int> repository, IMapper mapper) : IPassengerCrudService
{
    /// <summary>
    /// Creates a new <see cref="Passenger"/> entity and returns its DTO.
    /// </summary>
    /// <param name="dto">Passenger data for creation.</param>
    /// <returns>The created <see cref="PassengerDto"/>.</returns>
    public async Task<PassengerDto> Create(PassengerCreateUpdateDto dto)
    {
        var entity = mapper.Map<Passenger>(dto);

        var result = await repository.Create(entity);
        
        return mapper.Map<PassengerDto>(result);
    }

    /// <summary>
    /// Retrieves a <see cref="PassengerDto"/> by its ID.
    /// </summary>
    /// <param name="passengerId">The ID of the passenger to retrieve.</param>
    /// <returns>The <see cref="PassengerDto"/> corresponding to the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public async Task<PassengerDto> Get(int passengerId)
    {
        var entity = await repository.Get(passengerId)
                     ?? throw new KeyNotFoundException($"Entity with ID {passengerId} not found");
        return mapper.Map<PassengerDto>(entity);
    }

    /// <summary>
    /// Retrieves all passengers as DTOs.
    /// </summary>
    /// <returns>List of <see cref="PassengerDto"/>.</returns>
    public async Task<IList<PassengerDto>> GetAll() => mapper.Map<List<PassengerDto>>(await repository.GetAll());

    /// <summary>
    /// Updates an existing <see cref="Passenger"/> entity.
    /// </summary>
    /// <param name="dto">Updated passenger data.</param>
    /// <param name="passengerId">The ID of the passenger to update.</param>
    /// <returns>The updated <see cref="PassengerDto"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public async Task<PassengerDto> Update(PassengerCreateUpdateDto dto, int passengerId)
    {
        var entity = await repository.Get(passengerId)
                     ?? throw new KeyNotFoundException($"Entity with ID {passengerId} not found");

        mapper.Map(dto, entity);
        var result = await repository.Update(entity);

        return mapper.Map<PassengerDto>(result);
    }

    /// <summary>
    /// Deletes a passenger by its ID.
    /// </summary>
    /// <param name="passengerId">The ID of the passenger to delete.</param>
    public async Task<bool> Delete(int passengerId) => await repository.Delete(passengerId);

    /// <summary>
    /// Retrieves all tickets associated with a specific passenger.
    /// </summary>
    /// <param name="passengerId">The unique identifier of the passenger.</param>
    /// <returns>A list of <see cref="TicketDto"/> belonging to the passenger.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the passenger does not exist.</exception>
    public async Task<IList<TicketDto>> GetTickets(int passengerId)
    {
        var entity = await repository.Get(passengerId)
                    ?? throw new KeyNotFoundException($"Entity with ID {passengerId} not found");

        return mapper.Map<List<TicketDto>>(entity.Tickets!);
    }
}
