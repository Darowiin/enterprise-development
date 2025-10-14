using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing tickets.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController(IApplicationService<TicketDto, TicketCreateUpdateDto, int> service, ILogger<TicketController> logger) 
    : CrudControllerBase<TicketDto, TicketCreateUpdateDto, int> (service, logger) { }