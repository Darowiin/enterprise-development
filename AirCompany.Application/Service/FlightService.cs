using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using AirCompany.Domain;
using AirCompany.Domain.Model;
using MapsterMapper;

namespace AirCompany.Application.Service;

/// <summary>
/// Service that provides CRUD operations and unit-test result for <see cref="Flight"/> entities.
/// Implements <see cref="IFlightCRUDService"/> for operations.
/// </summary>
public class FlightService(IRepository<Flight, int> repository, IMapper mapper) : IFlightCRUDService
{
    /// <summary>
    /// Creates a new <see cref="Flight"/> entity and returns its DTO.
    /// </summary>
    /// <param name="dto">Flight data for creation.</param>
    /// <returns>The created <see cref="FlightDto"/>.</returns>
    public FlightDto Create(FlightCreateUpdateDto dto)
    {
        var entity = mapper.Map<Flight>(dto);

        repository.Create(entity);

        return mapper.Map<FlightDto>(entity);
    }

    /// <summary>
    /// Retrieves a <see cref="FlightDto"/> by its ID.
    /// </summary>
    /// <param name="flightId">The ID of the flight to retrieve.</param>
    /// <returns>The <see cref="FlightDto"/> corresponding to the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public FlightDto Get(int flightId)
    {
        var entity = repository.Get(flightId)
                     ?? throw new KeyNotFoundException($"Entity with ID {flightId} not found");
        return mapper.Map<FlightDto>(entity);
    }

    /// <summary>
    /// Retrieves all flights as DTOs.
    /// </summary>
    /// <returns>List of <see cref="FlightDto"/>.</returns>
    public List<FlightDto> GetAll() => mapper.Map<List<FlightDto>>(repository.GetAll());

    /// <summary>
    /// Updates an existing <see cref="Flight"/> entity.
    /// </summary>
    /// <param name="dto">Updated flight data.</param>
    /// <param name="flightId">The ID of the flight to update.</param>
    /// <returns>The updated <see cref="FlightDto"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no entity with the specified ID exists.</exception>
    public FlightDto Update(FlightCreateUpdateDto dto, int flightId)
    {
        var entity = repository.Get(flightId)
                     ?? throw new KeyNotFoundException($"Entity with ID {flightId} not found");

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<FlightDto>(entity);
    }

    /// <summary>
    /// Deletes a flight by its ID.
    /// </summary>
    /// <param name="flightId">The ID of the flight to delete.</param>
    public void Delete(int flightId) => repository.Delete(flightId);

    /// <summary>
    /// Returns the <see cref="AircraftModelDto"/> associated with the flight.
    /// </summary>
    public AircraftModelDto GetAircraftModel(int flightId)
    {
        var entity = repository.Get(flightId)
                     ?? throw new KeyNotFoundException($"Entity with ID {flightId} not found");

        return mapper.Map<AircraftModelDto>(entity.AircraftModel);
    }

    /// <summary>
    /// Returns all tickets for a flight.
    /// </summary>
    public List<TicketDto> GetTickets(int flightId)
    {
        var entity = repository.Get(flightId)
                     ?? throw new KeyNotFoundException($"Entity with ID {flightId} not found");

        return mapper.Map<List<TicketDto>>(entity.Tickets!);
    }

    /// <summary>
    /// Retrieves the top 5 flights with the largest number of passengers.
    /// </summary>
    /// <returns>List of <see cref="FlightDto"/> representing the top 5 flights by passenger count.</returns>
    public List<FlightDto> GetTop5FlightsByPassengerCount()
    {
        return mapper.Map<List<FlightDto>>(
            repository.GetAll()
                .OrderByDescending(f => f.Tickets?.Count ?? 0)
                .Take(5)
                .ToList()
        );
    }

    /// <summary>
    /// Retrieves all flights that have the minimal flight duration among all flights.
    /// </summary>
    /// <returns>List of <see cref="FlightDto"/> with minimal duration.</returns>
    public List<FlightDto> GetFlightsWithMinimalDuration()
    {
        var allFlights = repository.GetAll();
        if (allFlights.Count == 0)
            return [];

        var minDuration = allFlights.Min(f => f.FlightDuration ?? TimeSpan.MaxValue);
        var result = allFlights
            .Where(f => f.FlightDuration.HasValue && f.FlightDuration.Value == minDuration)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }

    /// <summary>
    /// Retrieves all passengers from the specified flight who have no baggage.
    /// </summary>
    /// <param name="flightId">The ID of the flight to check.</param>
    /// <returns>List of <see cref="PassengerDto"/> with zero or null baggage weight.</returns>
    public List<PassengerDto> GetPassengersWithZeroBaggageByFlight(int flightId)
    {
        var flight = repository.Get(flightId);
        if (flight is null) return [];

        var passengersWithNoBaggage = flight.Tickets?
            .Where(t => t.TotalBaggageWeightKg is null or 0)
            .Select(t => t.Passenger)
            .ToList() ?? [];

        var passengersDto = mapper.Map<List<PassengerDto>>(passengersWithNoBaggage);

        return passengersDto;
    }

    /// <summary>
    /// Retrieves flights for a specific aircraft model that occurred within the specified date range.
    /// </summary>
    /// <param name="modelId">The ID of the aircraft model.</param>
    /// <param name="startDate">Start date of the period.</param>
    /// <param name="endDate">End date of the period.</param>
    /// <returns>List of <see cref="FlightDto"/> matching the filter.</returns>
    public List<FlightDto> GetFlightsByModelAndPeriod(int modelId, DateTime startDate, DateTime endDate)
    {
        var result = repository.GetAll()
            .Where(f => f.AircraftModel?.Id == modelId &&
                        f.DepartureDateTime.HasValue &&
                        f.DepartureDateTime.Value >= startDate &&
                        f.DepartureDateTime.Value <= endDate)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }

    /// <summary>
    /// Retrieves all flights between the specified departure and arrival airports.
    /// </summary>
    /// <param name="departure">Departure airport code or name.</param>
    /// <param name="arrival">Arrival airport code or name.</param>
    /// <returns>List of <see cref="FlightDto"/> for the specified route.</returns>
    public List<FlightDto> GetFlightsByRoute(string departure, string arrival)
    {
        var result = repository.GetAll()
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }
}