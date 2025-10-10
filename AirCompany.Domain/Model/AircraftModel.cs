namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a specific <see cref="AircraftModel"/> (e.g., "A320neo").
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Unique identifier of the <see cref="AircraftModel"/>.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Name of the <see cref="AircraftModel"/> (e.g., "A320neo").
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// The <see cref="AircraftFamily"/> this <see cref="AircraftModel"/> belongs to.
    /// </summary>
    public required AircraftFamily Family { get; set; }

    /// <summary>
    /// Maximum flight range of this <see cref="AircraftModel"/> in kilometers.
    /// </summary>
    public required double FlightRangeKm { get; set; }

    /// <summary>
    /// Maximum passenger capacity of this <see cref="AircraftModel"/>.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum cargo capacity of this <see cref="AircraftModel"/> in kilograms.
    /// </summary>
    public required double CargoCapacityKg { get; set; }

    /// <summary>
    /// Collection of <see cref="Flight"/>s operated by this <see cref="AircraftModel"/>.
    /// </summary>
    public List<Flight>? Flights { get; set; } = [];
}