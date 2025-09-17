namespace AirCompany.Domain.Models;

/// <summary>
/// Represents an aircraft family (e.g., A320 Family, Boeing 737 Family).
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Unique identifier of the aircraft family.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the aircraft family (e.g., "A320 Family").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Manufacturer of the aircraft family (e.g., "Airbus").
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Navigation property: list of aircraft models in this family.
    /// </summary>
    public List<AircraftModel> Models { get; set; } = [];
}