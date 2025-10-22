using AirCompany.Application.Contracts.Flight;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing tickets.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController(ITicketCrudService service, ILogger<TicketController> logger)
    : CrudControllerBase<TicketDto, TicketCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves the passenger associated with the specified ticket.
    /// </summary>
    /// <param name="id">The unique identifier of the ticket.</param>
    /// <returns>
    /// A <see cref="PassengerDto"/> if found; otherwise, 404 Not Found.
    /// </returns>
    [HttpGet("{id}/Passenger")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<PassengerDto>> GetPassenger(int id)
        => await ExecuteWithLogging(nameof(GetPassenger), async () =>
        {
            try
            {
                var result = await service.GetPassenger(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });

    /// <summary>
    /// Retrieves the flight associated with the specified ticket.
    /// </summary>
    /// <param name="id">The unique identifier of the ticket.</param>
    /// <returns>
    /// A <see cref="FlightDto"/> if found; otherwise, 404 Not Found.
    /// </returns>
    [HttpGet("{id}/Flight")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<FlightDto>> GetFlight(int id)
        => await ExecuteWithLogging(nameof(GetFlight), async () =>
        {
            try
            {
                var result = await service.GetFlight(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });
}

