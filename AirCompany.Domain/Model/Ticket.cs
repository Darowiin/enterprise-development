namespace AirCompany.Domain.Model;

/// <summary>
/// Represents a <see cref="Ticket"/> issued to a <see cref="Model.Passenger"/> 
/// for a specific <see cref="Model.Flight"/>.
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique identifier of the <see cref="Ticket"/>.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The <see cref="Model.Flight"/> associated with this <see cref="Ticket"/>.
    /// </summary>
    public required Flight Flight { get; set; }

    /// <summary>
    /// The <see cref="Model.Passenger"/> who owns this <see cref="Ticket"/>.
    /// </summary>
    public required Passenger Passenger { get; set; }

    /// <summary>
    /// Seat number assigned to this <see cref="Ticket"/> (e.g., "12A").
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Indicates whether the <see cref="Model.Passenger"/> has hand luggage for this <see cref="Ticket"/>.
    /// </summary>
    public bool? HasHandLuggage { get; set; }

    /// <summary>
    /// Total baggage weight in kilograms for this <see cref="Ticket"/>.
    /// </summary>
    public double? TotalBaggageWeightKg { get; set; }
}
