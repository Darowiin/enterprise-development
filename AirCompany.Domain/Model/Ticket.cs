using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a ticket issued to a <see cref="Model.Passenger"/> 
/// for a specific <see cref="Model.Flight"/>.
/// </summary>
[Table("tickets")]
public class Ticket
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="Flight"/> this ticket is associated with.
    /// </summary>
    [Column("flight_id")]
    public required int FlightId { get; set; }

    /// <summary>
    /// The <see cref="Model.Flight"/> associated with this ticket.
    /// </summary>
    public virtual Flight? Flight { get; set; }

    /// <summary>
    /// Foreign key referencing the <see cref="Model.Passenger"/> who owns this ticket.
    /// </summary>
    [Column("passenger_id")]
    public required int PassengerId { get; set; }

    /// <summary>
    /// The <see cref="Model.Passenger"/> who owns this ticket.
    /// </summary>
    public virtual Passenger? Passenger { get; set; }

    /// <summary>
    /// Seat number assigned to this ticket (e.g., "12A").
    /// </summary>
    [Column("seat_number")]
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Indicates whether the <see cref="Model.Passenger"/> has hand luggage for this ticket.
    /// </summary>
    [Column("has_hand_luggage")]
    public bool? HasHandLuggage { get; set; }

    /// <summary>
    /// Total baggage weight in kilograms for this ticket.
    /// </summary>
    [Column("total_baggage_weight")]
    public double? TotalBaggageWeightKg { get; set; }
}