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
    : ReadControllerBase<AircraftModelDto, int> (service, logger) 
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
    public ActionResult<AircraftFamilyDto> GetAircraftFamily(int id)
        => ExecuteWithLogging(nameof(GetAircraftFamily), () =>
        {
            try
            {
                var result = service.GetAircraftFamily(id);
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
    public ActionResult<List<FlightDto>> GetFlights(int id)
        => ExecuteWithLogging(nameof(GetFlights), () =>
        {
            try
            {
                var result = service.GetFlights(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });
}