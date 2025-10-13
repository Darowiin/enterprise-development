namespace AirCompany.Application.Contracts.Flight;
public record FlightDto
    (
    int Id,
    string Code,
    string DepartureAirport,
    string ArrivalAirport, 
    DateTime? DepartureDateTime, 
    DateTime? ArrivalDateTime, 
    TimeSpan? FlightDuration, 
    int AircraftModelId,
    List<int>? TicketIds
    );