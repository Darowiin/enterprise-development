namespace AirCompany.Application.Contracts.Ticket;
public record TicketDto(int Id, int FlightId, int PassengerId, string SeatNumber, bool? HasHandLuggage, double? TotalBaggageWeightKg);