using AirCompany.Infrastructure.InMemory.Repository;
using MapsterMapper;

namespace AirCompany.Application.Service;

public class FlightService(IRepository<Flight, int> repository, IMapper mapper) : IFlightService
{
    public FlightDto Create(FlightCreateUpdateDto dto)
    {
        var entity = mapper.Map<Flight>(dto);

        repository.Create(entity);

        return mapper.Map<FlightDto>(entity);
    }

    public FlightDto Get(int dtoId) => mapper.Map<FlightDto>(repository.Get(dtoId));

    public List<FlightDto> GetAll() => mapper.Map<List<FlightDto>>(repository.GetAll());


    public FlightDto Update(FlightCreateUpdateDto dto, int dtoId)
    {
        var entity = repository.Get(dtoId);

        mapper.Map(dto, entity);
        repository.Update(entity);

        return mapper.Map<FlightDto>(entity);
    }

    public void Delete(int dtoId) => repository.Delete(dtoId);

    public List<FlightDto> GetTop5FlightsByPassengerCount()
    {
        return mapper.Map<List<FlightDto>>(
            repository.GetAll()
                .OrderByDescending(f => f.Tickets?.Count ?? 0)
                .Take(5)
                .ToList()
        );
    }

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

    public List<FlightDto> GetPassengersWithZeroBaggageByFlight(int flightId)
    {
        var flight = repository.Get(flightId);
        if (flight is null) return [];

        var passengersWithNoBaggage = flight.Tickets?
            .Where(t => t.TotalBaggageWeightKg is null or 0)
            .Select(t => t.Passenger)
            .ToList() ?? [];

        var passengersDto = mapper.Map<List<PassengerDto>>(passengersWithNoBaggage);

        var flightDto = new FlightDto(
            flight.Id,
            flight.Code,
            flight.DepartureAirport,
            flight.ArrivalAirport,
            flight.DepartureDateTime,
            flight.ArrivalDateTime,
            flight.FlightDuration,
            flight.AircraftModel.Id,
            flight.Tickets?.Select(t => t.Id).ToList(),
            passengersDto
        );

        return [flightDto];
    }

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

    public List<FlightDto> GetFlightsByRoute(string departure, string arrival)
    {
        var result = repository.GetAll()
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }
}