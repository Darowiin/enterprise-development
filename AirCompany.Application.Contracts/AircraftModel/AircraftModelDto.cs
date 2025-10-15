namespace AirCompany.Application.Contracts.AircraftModel;

/// <summary>
/// DTO representing an aircraft model.
/// </summary>
/// <param name="Id">Unique identifier of the aircraft model.</param>
/// <param name="ModelName">Name of the aircraft model.</param>
/// <param name="FlightRangeKm">Maximum flight range in kilometers.</param>
/// <param name="PassengerCapacity">Number of passengers the model can carry.</param>
/// <param name="CargoCapacityKg">Cargo capacity in kilograms.</param>
public record AircraftModelDto(int Id, string ModelName, double FlightRangeKm, int PassengerCapacity, double CargoCapacityKg);