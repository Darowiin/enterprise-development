using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.Passenger;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing passengers.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IApplicationService<PassengerDto, PassengerCreateUpdateDto, int> service, ILogger<PassengerController> logger) 
    : CrudControllerBase<PassengerDto, PassengerCreateUpdateDto, int> (service, logger) { }