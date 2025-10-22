using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing flight-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IFlightCrudService service, ILogger<FlightController> logger)
    : CrudControllerBase<FlightDto, FlightCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves the aircraft model of a flight.
    /// </summary>
    [HttpGet("{id}/AircraftModel")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<AircraftModelDto>> GetAircraftModel(int id)
        => await ExecuteWithLogging(nameof(GetAircraftModel), async () =>
        {
            try
            {
                var result = await service.GetAircraftModel(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });

    /// <summary>
    /// Retrieves all tickets of a flight.
    /// </summary>
    [HttpGet("{id}/Tickets")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<TicketDto>>> GetTickets(int id)
        => await ExecuteWithLogging(nameof(GetTickets), async () =>
        {
            try
            {
                var result = await service.GetTickets(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });

    /// <summary>
    /// Returns top 5 flights ordered by passenger count.
    /// </summary>
    [HttpGet("top5-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetTop5FlightsByPassengerCount()
        => await ExecuteWithLogging(nameof(GetTop5FlightsByPassengerCount), async () =>
        {
            var result = await service.GetTop5FlightsByPassengerCount();
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights with the minimal flight duration.
    /// </summary>
    [HttpGet("minimal-duration")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsWithMinimalDuration()
        => await ExecuteWithLogging(nameof(GetFlightsWithMinimalDuration), async () =>
        {
            var result = await service.GetFlightsWithMinimalDuration();
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns passengers with zero baggage for a specific flight.
    /// </summary>
    [HttpGet("zero-baggage")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<PassengerDto>>> GetPassengersWithZeroBaggageByFlight([FromQuery] int flightId)
        => await ExecuteWithLogging(nameof(GetPassengersWithZeroBaggageByFlight), async () =>
        {
            var result = await service.GetPassengersWithZeroBaggageByFlight(flightId);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights for a given aircraft model within a specified date range.
    /// </summary>
    [HttpGet("by-model-period")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsByModelAndPeriod([FromQuery] int modelId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        => await ExecuteWithLogging(nameof(GetFlightsByModelAndPeriod), async () =>
        {
            var result = await service.GetFlightsByModelAndPeriod(modelId, startDate, endDate);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights matching the specified departure and arrival airports.
    /// </summary>
    [HttpGet("by-route")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsByRoute([FromQuery] string departure, [FromQuery] string arrival)
        => await ExecuteWithLogging(nameof(GetFlightsByRoute), async () =>
        {
            var result = await service.GetFlightsByRoute(departure, arrival);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });
}
