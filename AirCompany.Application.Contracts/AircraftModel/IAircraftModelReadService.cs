using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.Flight;

namespace AirCompany.Application.Contracts.AircraftModel;

/// <summary>
/// Aircraft model service interface for performing read operations.
/// </summary>
public interface IAircraftModelReadService : IApplicationReadService<AircraftModelDto, int>
{
    /// <summary>
    /// Retrieves the <see cref="AircraftFamilyDto"/> that the specified aircraft model belongs to.
    /// </summary>
    /// <param name="modelId">The unique identifier of the aircraft model.</param>
    /// <returns>The <see cref="AircraftFamilyDto"/> associated with the model.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no aircraft model with the given <paramref name="modelId"/> exists.
    /// </exception>
    public AircraftFamilyDto GetAircraftFamily(int modelId);

    /// <summary>
    /// Retrieves all <see cref="FlightDto"/> objects associated with the specified aircraft model.
    /// </summary>
    /// <param name="modelId">The unique identifier of the aircraft model.</param>
    /// <returns>A list of flights operated with this aircraft model.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no aircraft model with the given <paramref name="modelId"/> exists.
    /// </exception>
    public List<FlightDto> GetFlights(int modelId);
}