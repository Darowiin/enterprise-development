using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a specific aircraft model (e.g., "A320neo").
/// </summary>
[Table("aircraft_models")]
public class AircraftModel
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Name of the aircraft model (e.g., "A320neo").
    /// </summary>
    [Column("model_name")]
    public required string ModelName { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="AircraftFamily"/> this aircraft model belongs to.
    /// </summary>
    [Column("family_id")]
    public required int FamilyId { get; set; }

    /// <summary>
    /// The <see cref="AircraftFamily"/> this aircraft model belongs to.
    /// </summary>
    public virtual AircraftFamily? Family { get; set; }

    /// <summary>
    /// Maximum flight range of this aircraft model in kilometers.
    /// </summary>
    [Column("flight_range")]
    public required double FlightRangeKm { get; set; }

    /// <summary>
    /// Maximum passenger capacity of this aircraft model.
    /// </summary>
    [Column("passenger_capacity")]
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum cargo capacity of this aircraft model in kilograms.
    /// </summary>
    [Column("cargo_capacity")]
    public required double CargoCapacityKg { get; set; }

    /// <summary>
    /// Collection of <see cref="Flight"/>s operated by this aircraft model.
    /// </summary>
    public virtual List<Flight>? Flights { get; set; } = [];
}