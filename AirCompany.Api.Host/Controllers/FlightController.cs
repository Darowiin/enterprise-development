using AirCompany.Application.Contracts.Flight;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing flight-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IFlightService service, ILogger<FlightController> logger)
    : CrudControllerBase<FlightDto, FlightCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Returns top 5 flights ordered by passenger count.
    /// </summary>
    [HttpGet("top5-flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<FlightDto>> GetTop5FlightsByPassengerCount()
        => ExecuteWithLogging(nameof(GetTop5FlightsByPassengerCount), () =>
        {
            var result = service.GetTop5FlightsByPassengerCount();
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights with the minimal flight duration.
    /// </summary>
    [HttpGet("minimal-duration")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<FlightDto>> GetFlightsWithMinimalDuration()
        => ExecuteWithLogging(nameof(GetFlightsWithMinimalDuration), () =>
        {
            var result = service.GetFlightsWithMinimalDuration();
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns passengers with zero baggage for a specific flight.
    /// </summary>
    [HttpGet("zero-baggage")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<FlightDto>> GetPassengersWithZeroBaggageByFlight([FromQuery] int flightId)
        => ExecuteWithLogging(nameof(GetPassengersWithZeroBaggageByFlight), () =>
        {
            var result = service.GetPassengersWithZeroBaggageByFlight(flightId);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights for a given aircraft model within a specified date range.
    /// </summary>
    [HttpGet("by-model-period")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<FlightDto>> GetFlightsByModelAndPeriod([FromQuery] int modelId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        => ExecuteWithLogging(nameof(GetFlightsByModelAndPeriod), () =>
        {
            var result = service.GetFlightsByModelAndPeriod(modelId, startDate, endDate);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });

    /// <summary>
    /// Returns flights matching the specified departure and arrival airports.
    /// </summary>
    [HttpGet("by-route")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<FlightDto>> GetFlightsByRoute([FromQuery] string departure, [FromQuery] string arrival)
        => ExecuteWithLogging(nameof(GetFlightsByRoute), () =>
        {
            var result = service.GetFlightsByRoute(departure, arrival);
            return result is not null && result.Count > 0 ? Ok(result) : NoContent();
        });
}
