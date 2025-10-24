namespace AirCompany.Domain.Model;


/// <summary>
/// Represents a scheduled flight between two airports.
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Flight code (e.g., "SU1234").
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Departure airport for this flight (IATA code or city name).
    /// </summary>
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Arrival airport for this flight (IATA code or city name).
    /// </summary>
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Scheduled departure date and time of this flight.
    /// </summary>
    public DateTime? DepartureDateTime { get; set; }

    /// <summary>
    /// Scheduled arrival date and time of this flight.
    /// </summary>
    public DateTime? ArrivalDateTime { get; set; }

    /// <summary>
    /// Total duration of this flight.
    /// </summary>
    public TimeSpan? FlightDuration { get; set; }

    public required int ModelId { get; set; }

    /// <summary>
    /// The <see cref="Model.AircraftModel"/> operating this flight.
    /// </summary>
    public virtual AircraftModel? Model { get; set; }

    /// <summary>
    /// Collection of <see cref="Ticket"/>s issued for this flight.
    /// </summary>
    public virtual List<Ticket>? Tickets { get; set; } = [];
}