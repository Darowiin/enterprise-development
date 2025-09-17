namespace AirCompany.Domain.Models;

/// <summary>
/// Represents a specific aircraft model (e.g., A320neo).
/// </summary>
public class AircraftModel
{
    /// <summary>
    /// Unique identifier of the aircraft model.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the aircraft model (e.g., "A320neo").
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// Navigation property: the family this model belongs to.
    /// </summary>
    public required AircraftFamily Family { get; set; }

    /// <summary>
    /// Maximum flight range of the aircraft in kilometers.
    /// </summary>
    public required double FlightRangeKm { get; set; }

    /// <summary>
    /// Maximum passenger capacity of the aircraft.
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum cargo capacity of the aircraft in kilograms.
    /// </summary>
    public required decimal CargoCapacityKg { get; set; }

    /// <summary>
    /// Navigation property: list of flights using this aircraft model.
    /// </summary>
    public List<Flight> Flights { get; set; } = [];
}