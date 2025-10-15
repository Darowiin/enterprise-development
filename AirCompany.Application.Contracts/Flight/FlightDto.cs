using AirCompany.Application.Contracts.Passenger;

namespace AirCompany.Application.Contracts.Flight;

/// <summary>
/// DTO representing a flight.
/// </summary>
/// <param name="Id">Unique identifier of the flight.</param>
/// <param name="Code">Flight code.</param>
/// <param name="DepartureAirport">Departure airport for this flight (IATA code or city name).</param>
/// <param name="ArrivalAirport">Arrival airport for this flight (IATA code or city name).</param>
/// <param name="DepartureDateTime">Departure date and time.</param>
/// <param name="ArrivalDateTime">Arrival date and time.</param>
/// <param name="FlightDuration">Duration of the flight.</param>
public record FlightDto(int Id, string Code, string DepartureAirport, string ArrivalAirport, DateTime? DepartureDateTime, DateTime? ArrivalDateTime, TimeSpan? FlightDuration);