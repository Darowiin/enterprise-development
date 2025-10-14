using AirCompany.Application.Contracts;
using AirCompany.Application.Contracts.AircraftFamily;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Controller responsible for managing aircraft families.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftFamilyController(IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int> service, ILogger<AircraftFamilyController> logger) 
    : CrudControllerBase<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int> (service, logger) { }