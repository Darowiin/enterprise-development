namespace AirCompany.Domain.Model;

/// <summary>
/// Represents an aircraft family (e.g., "A320 Family", "Boeing 737 Family").
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Name of the aircraft family (e.g., "A320 Family").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer of this aircraft family (e.g., "Airbus").
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Collection of <see cref="AircraftModel"/>s belonging to this aircraft family.
    /// </summary>
    public virtual List<AircraftModel>? Models { get; set; } = [];
}