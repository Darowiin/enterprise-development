using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Model;

/// <summary>
/// Represents an aircraft family (e.g., "A320 Family", "Boeing 737 Family").
/// </summary>
[Table("aircraft_families")]
public class AircraftFamily
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Name of the aircraft family (e.g., "A320 Family").
    /// </summary>
    [Column("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer of this aircraft family (e.g., "Airbus").
    /// </summary>
    [Column("manufacturer")]
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Collection of <see cref="AircraftModel"/>s belonging to this aircraft family.
    /// </summary>
    public virtual List<AircraftModel>? Models { get; set; } = [];
}