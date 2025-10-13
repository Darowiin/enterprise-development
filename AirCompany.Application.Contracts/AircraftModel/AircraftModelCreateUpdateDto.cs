namespace AirCompany.Application.Contracts.AircraftModel;
public record AircraftModelCreateUpdateDto
    (
    string ModelName,
    int AircraftFamilyId,
    double FlightRangeKm,
    int PassengerCapacity,
    double CargoCapacityKg
    );