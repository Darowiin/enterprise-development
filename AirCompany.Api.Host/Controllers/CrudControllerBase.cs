using AirCompany.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Generic base controller providing CRUD endpoints for all entities.
/// </summary>
/// <typeparam name="TDto">DTO type returned by the API.</typeparam>
/// <typeparam name="TCreateUpdateDto">DTO type used for creation and update operations.</typeparam>
/// <typeparam name="TKey">Type of the entity identifier.</typeparam>
/// <param name="appService">Service for work with DTO.</param>
/// <param name="logger">Logger for information.</param>
[Route("api/[controller]")]
[ApiController]
public abstract class CrudControllerBase<TDto, TCreateUpdateDto, TKey>(
    IApplicationService<TDto, TCreateUpdateDto, TKey> appService,
    ILogger<CrudControllerBase<TDto, TCreateUpdateDto, TKey>> logger)
    : ControllerBase
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="newDto">Data for the new entity.</param>
    /// <returns>The created entity.</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Create([FromBody] TCreateUpdateDto newDto)
        => ExecuteWithLogging(nameof(Create), () =>
        {
            var result = appService.Create(newDto);
            return CreatedAtAction(nameof(Get), new { id = GetEntityId(result) }, result);
        });

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">Identifier of the entity to update.</param>
    /// <param name="newDto">Updated entity data.</param>
    /// <returns>The updated entity.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Edit(TKey id, [FromBody] TCreateUpdateDto newDto)
        => ExecuteWithLogging(nameof(Edit), () => Ok(appService.Update(newDto, id)));

    /// <summary>
    /// Deletes an entity by ID.
    /// </summary>
    /// <param name="id">Identifier of the entity to delete.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public IActionResult Delete(TKey id)
        => ExecuteWithLogging(nameof(Delete), () =>
        {
            appService.Delete(id);
            return Ok();
        });

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
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Get(TKey id)
        => ExecuteWithLogging(nameof(Get), () =>
        {
            var result = appService.Get(id);
            return result is not null ? Ok(result) : NoContent();
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

    /// <summary>
    /// Tries to extract the entity ID from the DTO using reflection.
    /// </summary>
    private static object? GetEntityId(TDto dto)
        => dto?.GetType().GetProperty("Id")?.GetValue(dto);
}