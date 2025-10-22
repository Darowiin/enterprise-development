using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using AirCompany.Domain;
using AirCompany.Domain.Model;
using MapsterMapper;

namespace AirCompany.Application.Service;

/// <summary>
/// Service providing read operations for <see cref="AircraftModel"/> entities.
/// Implements <see cref="IApplicationReadService{TDto, TKey}"/> for AircraftModel DTOs.
/// </summary>
public class AirCraftModelService(IRepository<AircraftModel, int> repository, IMapper mapper) : IAircraftModelReadService
{
    /// <summary>
    /// Retrieves a single <see cref="AircraftModelDto"/> by its unique identifier.
    /// </summary>
    /// <param name="modelId">The ID of the aircraft model to retrieve.</param>
    /// <returns>The <see cref="AircraftModelDto"/> corresponding to the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public async Task<AircraftModelDto> Get(int modelId)
    {
        var entity = await repository.Get(modelId)
                     ?? throw new KeyNotFoundException($"Entity with ID {modelId} not found");
        return mapper.Map<AircraftModelDto>(entity);
    }

    /// <summary>
    /// Retrieves all <see cref="AircraftModelDto"/> entities from the repository.
    /// </summary>
    /// <returns>A list of all aircraft model DTOs.</returns>
    public async Task<IList<AircraftModelDto>> GetAll() => mapper.Map<List<AircraftModelDto>>(await repository.GetAll());

    /// <summary>
    /// Retrieves the <see cref="AircraftFamilyDto"/> associated with a given aircraft model.
    /// </summary>
    /// <param name="modelId">The ID of the aircraft model.</param>
    /// <returns>The corresponding <see cref="AircraftFamilyDto"/>.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if the aircraft model with the given ID does not exist.
    /// </exception>
    public async Task<AircraftFamilyDto> GetAircraftFamily(int modelId)
    {
        var entity = await repository.Get(modelId)
                    ?? throw new KeyNotFoundException($"Entity with ID {modelId} not found");

        return mapper.Map<AircraftFamilyDto>(entity.Family);
    }

    /// <summary>
    /// Retrieves all <see cref="FlightDto"/> entities linked to a specific aircraft model.
    /// </summary>
    /// <param name="modelId">The ID of the aircraft model whose flights should be retrieved.</param>
    /// <returns>A list of <see cref="FlightDto"/> related to the specified model.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if the aircraft model with the given ID does not exist.
    /// </exception>
    public async Task<IList<FlightDto>> GetFlights(int modelId)
    {
        var entity = await repository.Get(modelId)
                    ?? throw new KeyNotFoundException($"Entity with ID {modelId} not found");

        return mapper.Map<List<FlightDto>>(entity.Flights!);
    }
}