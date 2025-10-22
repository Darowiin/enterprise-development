using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing passengers.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IPassengerCrudService service, ILogger<PassengerController> logger)
    : CrudControllerBase<PassengerDto, PassengerCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves all tickets associated with the specified passenger.
    /// </summary>
    /// <param name="id">The unique identifier of the passenger.</param>
    /// <returns>
    /// <see cref="ActionResult{T}"/> containing a list of <see cref="TicketDto"/> 
    /// or an appropriate error response (404 if passenger not found).
    /// </returns>
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
}