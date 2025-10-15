using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.AircraftFamily;
using AirCompany.Application.Contracts.AircraftModel;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing aircraft families and their associated aircraft models.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftFamilyController(IAircraftFamilyReadService service, ILogger<AircraftFamilyController> logger) 
    : ReadControllerBase<AircraftFamilyDto, int> (service, logger) 
{
    /// <summary>
    /// Retrieves all aircraft models belonging to a specific aircraft family.
    /// </summary>
    /// <param name="id">The unique identifier of the aircraft family.</param>
    /// <returns>
    /// A list of <see cref="AircraftModelDto"/> associated with the specified family.
    /// Returns <see cref="NotFoundResult"/> if the family does not exist.
    /// </returns>
    [HttpGet("{id}/AircraftModels")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<List<AircraftModelDto>> GetAircraftModels(int id)
        => ExecuteWithLogging(nameof(GetAircraftModels), () =>
        {
            try
            {
                var result = service.GetAircraftModels(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });
}