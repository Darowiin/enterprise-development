namespace AirCompany.Domain.Models;

/// <summary>
/// Represents an <see cref="AircraftFamily"/> (e.g., "A320 Family", "Boeing 737 Family").
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Unique identifier of the <see cref="AircraftFamily"/>.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Name of the <see cref="AircraftFamily"/> (e.g., "A320 Family").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer of this <see cref="AircraftFamily"/> (e.g., "Airbus").
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Collection of <see cref="AircraftModel"/>s belonging to this <see cref="AircraftFamily"/>.
    /// </summary>
    public List<AircraftModel>? Models { get; set; } = [];
}