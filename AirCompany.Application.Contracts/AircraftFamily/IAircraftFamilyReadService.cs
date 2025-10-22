using AirCompany.Application.Contracts.AircraftModel;

namespace AirCompany.Application.Contracts.AircraftFamily;

/// <summary>
/// Aircraft family service interface for performing read operations.
/// </summary>
public interface IAircraftFamilyReadService : IApplicationReadService<AircraftFamilyDto, int>
{
    /// <summary>
    /// Retrieves a collection of <see cref="AircraftModelDto"/> objects
    /// that belong to the specified aircraft family.
    /// </summary>
    /// <param name="familyId">The unique identifier of the aircraft family.</param>
    /// <returns>A list of aircraft models associated with the specified family.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if an aircraft family with the given <paramref name="familyId"/> exists.
    /// </exception>
    public Task<IList<AircraftModelDto>> GetAircraftModels(int familyId);
}