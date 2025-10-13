namespace AirCompany.Application.Contracts.AircraftFamily;
public record AircraftFamilyDto
    (
    int Id,
    string Name,
    string Manufacturer,
    string ArrivalAirport, 
    List<int>? AircraftModelIds
    );