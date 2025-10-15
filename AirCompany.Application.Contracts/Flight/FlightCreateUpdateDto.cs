namespace AirCompany.Application.Contracts.Flight;

/// <summary>
/// DTO used for creating or updating flight data.
/// </summary>
/// <param name="Code">Flight code.</param>
/// <param name="DepartureAirport">Departure airport for this flight (IATA code or city name).</param>
/// <param name="ArrivalAirport">Arrival airport for this flight (IATA code or city name).</param>
/// <param name="DepartureDateTime">Departure date and time.</param>
/// <param name="ArrivalDateTime">Arrival date and time.</param>
/// <param name="FlightDuration">Duration of the flight.</param>
/// <param name="AircraftModelId">ID of the aircraft model used for the flight.</param>
public record FlightCreateUpdateDto(string Code, string DepartureAirport, string ArrivalAirport, DateTime? DepartureDateTime, DateTime? ArrivalDateTime, TimeSpan? FlightDuration, int AircraftModelId);