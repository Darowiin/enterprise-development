namespace AirCompany.Application.Contracts.Ticket;

/// <summary>
/// DTO used for creating or updating ticket data.
/// </summary>
/// <param name="FlightId">ID of the flight associated with the ticket.</param>
/// <param name="PassengerId">ID of the passenger who owns the ticket.</param>
/// <param name="SeatNumber">Assigned seat number.</param>
/// <param name="HasHandLuggage">Whether the passenger has hand luggage.</param>
/// <param name="TotalBaggageWeightKg">Total baggage weight in kilograms.</param>
public record TicketCreateUpdateDto(int FlightId, int PassengerId, string SeatNumber, bool? HasHandLuggage, double? TotalBaggageWeightKg);