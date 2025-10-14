namespace AirCompany.Application.Contracts.Flight;

/// <summary>
/// Service interface for managing <see cref="Flight"/> entities.
/// Provides CRUD operations and specialized queries for flights.
/// </summary>
public interface IFlightService : IApplicationService<FlightDto, FlightCreateUpdateDto, int>
{
    /// <summary>
    /// Returns the top 5 flights ordered by the number of passengers.
    /// </summary>
    /// <returns>List of <see cref="FlightDto"/> representing top 5 flights.</returns>
    public List<FlightDto> GetTop5FlightsByPassengerCount();

    /// <summary>
    /// Returns flights with the minimal flight duration among all flights.
    /// </summary>
    /// <returns>List of <see cref="FlightDto"/> with shortest duration.</returns>
    public List<FlightDto> GetFlightsWithMinimalDuration();

    /// <summary>
    /// Returns passengers with zero checked baggage for a specific flight.
    /// </summary>
    /// <param name="flightId">Flight identifier.</param>
    /// <returns>List of <see cref="FlightDto"/> containing passengers with no baggage.</returns>
    public List<FlightDto> GetPassengersWithZeroBaggageByFlight(int flightId);

    /// <summary>
    /// Returns flights for a given aircraft model within a specified period.
    /// </summary>
    /// <param name="modelId">Aircraft model identifier.</param>
    /// <param name="startDate">Start date of the period.</param>
    /// <param name="endDate">End date of the period.</param>
    /// <returns>List of <see cref="FlightDto"/> matching the criteria.</returns>
    public List<FlightDto> GetFlightsByModelAndPeriod(int modelId, DateTime startDate, DateTime endDate);

    /// <summary>
    /// Returns flights by departure and arrival airports.
    /// </summary>
    /// <param name="departure">Departure airport code.</param>
    /// <param name="arrival">Arrival airport code.</param>
    /// <returns>List of <see cref="FlightDto"/> for the given route.</returns>
    public List<FlightDto> GetFlightsByRoute(string departure, string arrival);
}
