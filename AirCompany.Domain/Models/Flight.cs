namespace AirCompany.Domain.Models;


/// <summary>
/// Represents a scheduled <see cref="Flight"/> between two airports.
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique identifier of the <see cref="Flight"/>.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Flight code (e.g., "SU1234").
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Departure airport for this <see cref="Flight"/> (IATA code or city name).
    /// </summary>
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Arrival airport for this <see cref="Flight"/> (IATA code or city name).
    /// </summary>
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Scheduled departure date and time of this <see cref="Flight"/>.
    /// </summary>
    public DateTime? DepartureDateTime { get; set; }

    /// <summary>
    /// Scheduled arrival date and time of this <see cref="Flight"/>.
    /// </summary>
    public DateTime? ArrivalDateTime { get; set; }

    /// <summary>
    /// Total duration of this <see cref="Flight"/>.
    /// </summary>
    public TimeSpan? FlightDuration { get; set; }

    /// <summary>
    /// The <see cref="AircraftModel"/> operating this <see cref="Flight"/>.
    /// </summary>
    public required AircraftModel AircraftModel { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s issued for this <see cref="Flight"/>.
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}