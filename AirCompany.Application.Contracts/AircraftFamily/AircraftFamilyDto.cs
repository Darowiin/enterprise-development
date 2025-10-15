namespace AirCompany.Application.Contracts.AircraftFamily;

/// <summary>
/// DTO representing an aircraft family.
/// Contains basic information about the family.
/// </summary>
/// <param name="Id">Unique identifier of the aircraft family.</param>
/// <param name="Name">Name of the aircraft family.</param>
/// <param name="Manufacturer">Manufacturer of the aircraft family.</param>
public record AircraftFamilyDto(int Id, string Name, string Manufacturer);