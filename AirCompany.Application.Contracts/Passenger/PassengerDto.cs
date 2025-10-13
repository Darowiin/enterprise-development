namespace AirCompany.Application.Contracts.Passenger;
public record PassengerDto(int Id, string PassportNumber, string FullName, DateOnly? BirthDate, List<int>? TicketIds);