using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Domain;
using AirCompany.Domain.Model;
using MapsterMapper;

namespace AirCompany.Application.Service;

/// <summary>
/// Service providing read operations for <see cref="AircraftFamily"/> entities.
/// Implements <see cref="IAircraftFamilyReadService"/> for AircraftFamily DTOs.
/// </summary>
public class AirCraftFamilyService(IRepository<AircraftFamily, int> repository, IMapper mapper) : IAircraftFamilyReadService
{
    /// <summary>
    /// Retrieves a single <see cref="AircraftFamilyDto"/> by its unique identifier.
    /// </summary>
    /// <param name="familyId">The ID of the aircraft family to retrieve.</param>
    /// <returns>The <see cref="AircraftFamilyDto"/> corresponding to the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public AircraftFamilyDto Get(int familyId)
    {
        var entity = repository.Get(familyId)
                     ?? throw new KeyNotFoundException($"Entity with ID {familyId} not found");
        return mapper.Map<AircraftFamilyDto>(entity);
    }

    /// <summary>
    /// Retrieves all <see cref="AircraftFamilyDto"/> entities from the repository.
    /// </summary>
    /// <returns>A list of all aircraft family DTOs.</returns>
    public List<AircraftFamilyDto> GetAll() => mapper.Map<List<AircraftFamilyDto>>(repository.GetAll());

    /// <summary>
    /// Retrieves all <see cref="AircraftModelDto"/> objects associated with a specific aircraft family.
    /// </summary>
    /// <param name="familyId">The ID of the aircraft family whose models should be returned.</param>
    /// <returns>A list of <see cref="AircraftModelDto"/> belonging to the specified family.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if the aircraft family with the given ID does not exist.
    /// </exception>
    public List<AircraftModelDto> GetAircraftModels(int familyId)
    {
        var entity = repository.Get(familyId)
                    ?? throw new KeyNotFoundException($"Entity with ID {familyId} not found");
        
        return mapper.Map<List<AircraftModelDto>>(entity.Models!);
    }
}