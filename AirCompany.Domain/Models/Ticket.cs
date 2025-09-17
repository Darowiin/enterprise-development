namespace AirCompany.Domain.Models;

/// <summary>
/// Represents a ticket for a flight.
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique identifier of the ticket.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Navigation property: flight associated with this ticket.
    /// </summary>
    public required Flight Flight { get; set; }

    /// <summary>
    /// Navigation property: passenger who owns this ticket.
    /// </summary>
    public required Passenger Passenger { get; set; }

    /// <summary>
    /// Seat number assigned to this ticket (e.g., "12A").
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Indicates whether the passenger has hand luggage.
    /// </summary>
    public bool HasHandLuggage { get; set; }

    /// <summary>
    /// Total baggage weight in kilograms.
    /// </summary>
    public decimal? TotalBaggageWeightKg { get; set; }
}
