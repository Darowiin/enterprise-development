namespace AirCompany.Application.Contracts.Ticket;
public record TicketCreateUpdateDto(int FlightId, int PassengerId, string SeatNumber, bool? HasHandLuggage, double? TotalBaggageWeightKg);