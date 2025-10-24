namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a ticket issued to a <see cref="Model.Passenger"/> 
/// for a specific <see cref="Model.Flight"/>.
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="Flight"/> this ticket is associated with.
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// The <see cref="Model.Flight"/> associated with this ticket.
    /// </summary>
    public virtual Flight? Flight { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="Model.Passenger"/> who owns this ticket.
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// The <see cref="Model.Passenger"/> who owns this ticket.
    /// </summary>
    public virtual Passenger? Passenger { get; set; }

    /// <summary>
    /// Seat number assigned to this ticket (e.g., "12A").
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Indicates whether the <see cref="Model.Passenger"/> has hand luggage for this ticket.
    /// </summary>
    public bool? HasHandLuggage { get; set; }

    /// <summary>
    /// Total baggage weight in kilograms for this ticket.
    /// </summary>
    public double? TotalBaggageWeightKg { get; set; }
}