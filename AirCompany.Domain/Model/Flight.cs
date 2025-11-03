using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a scheduled flight between two airports.
/// </summary>
[Table("flights")]
public class Flight
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Flight code (e.g., "SU1234").
    /// </summary>
    [Column("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Departure airport for this flight (IATA code or city name).
    /// </summary>
    [Column("departure_airport")]
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Arrival airport for this flight (IATA code or city name).
    /// </summary>
    [Column("arrival_airport")]
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Scheduled departure date and time of this flight.
    /// </summary>
    [Column("departure_datetime")]
    public DateTime? DepartureDateTime { get; set; }

    /// <summary>
    /// Scheduled arrival date and time of this flight.
    /// </summary>
    [Column("arrival_datetime")]
    public DateTime? ArrivalDateTime { get; set; }

    /// <summary>
    /// Total duration of this flight.
    /// </summary>
    [Column("flight_duration")]
    public TimeSpan? FlightDuration { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="AircraftModel"/> operating this flight.
    /// </summary>
    [Column("model_id")]
    public required int ModelId { get; set; }

    /// <summary>
    /// The <see cref="AircraftModel"/> operating this flight.
    /// </summary>
    public virtual AircraftModel? Model { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s issued for this flight.
    /// </summary>
    public virtual List<Ticket>? Tickets { get; set; } = [];
}