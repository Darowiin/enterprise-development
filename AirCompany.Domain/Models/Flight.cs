namespace AirCompany.Domain.Models;

/// <summary>
/// Represents a scheduled flight.
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique identifier of the flight.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Flight code (e.g., "SU1234").
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Departure airport (could be IATA code or city name).
    /// </summary>
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Arrival airport (could be IATA code or city name).
    /// </summary>
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Date and time of departure.
    /// </summary>
    public DateTime? DepartureDateTime { get; set; }

    /// <summary>
    /// Date and time of arrival.
    /// </summary>
    public DateTime? ArrivalDateTime { get; set; }

    /// <summary>
    /// Total flight duration.
    /// </summary>
    public TimeSpan? FlightDuration { get; set; }

    /// <summary>
    /// Navigation property: aircraft model for this flight.
    /// </summary>
    public required AircraftModel AircraftModel { get; set; }

    /// <summary>
    /// Navigation property: tickets issued for this flight.
    /// </summary>
    public List<Ticket> Tickets { get; set; } = [];
}