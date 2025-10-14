using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.AircraftModel;
using AirCompany.Application.Contracts.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing aircraft models.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftModelController(IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int> service, ILogger<AircraftModelController> logger) 
    : CrudControllerBase<AircraftModelDto, AircraftModelCreateUpdateDto, int> (service, logger) { }