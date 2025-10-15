using AirCompany.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Generic base controller providing only read endpoints for all entities.
/// </summary>
/// <typeparam name="TDto">DTO type returned by the API.</typeparam>
/// <typeparam name="TKey">Type of the entity identifier.</typeparam>
/// <param name="appService">Service for work with DTO.</param>
/// <param name="logger">Logger for information.</param>
[Route("api/[controller]")]
[ApiController]
public abstract class ReadControllerBase<TDto, TKey>(
    IApplicationReadService<TDto, TKey> appService,
    ILogger<ReadControllerBase<TDto, TKey>> logger)
    : ControllerBase
    where TDto : class
    where TKey : struct
{
    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>List of all entities.</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IList<TDto>> GetAll()
        => ExecuteWithLogging(nameof(GetAll), () => Ok(appService.GetAll()));

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">Entity identifier.</param>
    /// <returns>The entity if found, otherwise 204 No Content.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Get(TKey id)
        => ExecuteWithLogging(nameof(Get), () =>
        {
            try
            {
                var result = appService.Get(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        });

    /// <summary>
    /// Helper method for consistent logging and error handling.
    /// </summary>
    protected ActionResult ExecuteWithLogging(string method, Func<ActionResult> action)
    {
        logger.LogInformation("{Method} of {Controller} was called", method, GetType().Name);
        try
        {
            var result = action();
            logger.LogInformation("{Method} of {Controller} executed successfully", method, GetType().Name);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {Method} of {Controller}", method, GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }
}