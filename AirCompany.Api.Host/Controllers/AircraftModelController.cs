using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Flight;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing aircraft models.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftModelController(IAircraftModelReadService service, ILogger<AircraftModelController> logger)
    : ReadControllerBase<AircraftModelDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves the aircraft family to which the specified aircraft model belongs.
    /// </summary>
    /// <param name="id">The unique identifier of the aircraft model.</param>
    /// <returns>
    /// The <see cref="AircraftFamilyDto"/> associated with the model, or <see cref="NotFoundResult"/>
    /// if the model or family does not exist.
    /// </returns>
    [HttpGet("{id}/AircraftFamily")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<AircraftFamilyDto>> GetAircraftFamily(int id)
        => await ExecuteWithLogging(nameof(GetAircraftFamily), async () =>
        {
            try
            {
                var result = await service.GetAircraftFamily(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });

    /// <summary>
    /// Retrieves all flights associated with a specific aircraft model.
    /// </summary>
    /// <param name="id">The unique identifier of the aircraft model.</param>
    /// <returns>
    /// A list of <see cref="FlightDto"/> operated by the specified model, or
    /// <see cref="NotFoundResult"/> if the model does not exist.
    /// </returns>
    [HttpGet("{id}/Flights")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlights(int id)
        => await ExecuteWithLogging(nameof(GetFlights), async () =>
        {
            try
            {
                var result = await service.GetFlights(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });
}