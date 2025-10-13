namespace AirCompany.Application.Contracts.AircraftModel;
public record AircraftModelDto
    (
    int Id,
    string ModelName,
    int AircraftFamilyId,
    double FlightRangeKm, 
    int PassengerCapacity, 
    double CargoCapacityKg, 
    List<int>? FlightIds
    );