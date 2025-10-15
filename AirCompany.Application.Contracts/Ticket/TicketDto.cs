namespace AirCompany.Application.Contracts.Ticket;

/// <summary>
/// DTO representing a ticket.
/// </summary>
/// <param name="Id">Unique identifier of the ticket.</param>
/// <param name="SeatNumber">Assigned seat number.</param>
/// <param name="HasHandLuggage">Whether the passenger has hand luggage.</param>
/// <param name="TotalBaggageWeightKg">Total baggage weight in kilograms.</param>
public record TicketDto(int Id, string SeatNumber, bool? HasHandLuggage, double? TotalBaggageWeightKg);