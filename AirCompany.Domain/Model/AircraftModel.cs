namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a specific aircraft model (e.g., "A320neo").
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Name of the aircraft model (e.g., "A320neo").
    /// </summary>
    public required string ModelName { get; set; }

    public required int FamilyId { get; set; }

    /// <summary>
    /// The <see cref="AircraftFamily"/> this aircraft model belongs to.
    /// </summary>
    public virtual AircraftFamily? Family { get; set; }

    /// <summary>
    /// Maximum flight range of this aircraft model in kilometers.
    /// </summary>
    public required double FlightRangeKm { get; set; }

    /// <summary>
    /// Maximum passenger capacity of this aircraft model.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum cargo capacity of this aircraft model in kilograms.
    /// </summary>
    public required double CargoCapacityKg { get; set; }

    /// <summary>
    /// Collection of <see cref="Flight"/>s operated by this aircraft model.
    /// </summary>
    public virtual List<Flight>? Flights { get; set; } = [];
}