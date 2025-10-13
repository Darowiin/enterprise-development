namespace AirCompany.Application.Contracts.AircraftFamily;
public record AircraftFamilyCreateUpdateDto
    (
    string Name,
    string Manufacturer,
    string ArrivalAirport
    );