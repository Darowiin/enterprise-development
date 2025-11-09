using AirCompany.Application.Contracts.Ticket;
using AirCompany.Generator.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirCompany.Generator.Controller;

/// <summary>
/// Controller for generating ticket contracts and sending them via the message bus.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GeneratorController(ILogger<GeneratorController> logger, IProducerService producerService) : ControllerBase
{
    /// <summary>
    /// Generates and sends a specified number of ticket contracts in batches with a delay between batches.
    /// </summary>
    /// <param name="batchSize">Number of contracts per batch.</param>
    /// <param name="payloadLimit">Total number of contracts to generate and send.</param>
    /// <param name="waitTime">Delay in seconds between sending each batch.</param>
    /// <returns>List of generated <see cref="TicketCreateUpdateDto"/> objects.</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<TicketCreateUpdateDto>>> Get([FromQuery] int batchSize, [FromQuery] int payloadLimit, [FromQuery] int waitTime)
    {
        logger.LogInformation("Generating {limit} contracts via {batchSize} batches and {waitTime}s delay", payloadLimit, batchSize, waitTime);
        try
        {
            var list = new List<TicketCreateUpdateDto>(payloadLimit);
            var counter = 0;
            while (counter < payloadLimit)
            {
                var batch = TicketGenerator.GenerateContract(batchSize);
                var remaining = batch!.Count;
                var batchOffset = 0;

                while (remaining > 0)
                {
                    var currentBatch = batch.Skip(batchOffset).Take(remaining).ToList();

                    var result = await producerService.SendAsync(currentBatch);

                    if (!result.Success)
                    {
                        logger.LogWarning("Batch failed, regenerating only remaining {remaining} items...", remaining);
                        var newTickets = TicketGenerator.GenerateContract(remaining);
                        batch = [.. batch.Take(batchOffset), .. newTickets!];
                        continue;
                    }

                    var inserted = result.Inserted;
                    remaining -= inserted;
                    batchOffset += inserted;

                    if (remaining > 0)
                        logger.LogWarning("{remaining} items not inserted, retrying them...", remaining);
                }

                counter += batchSize;
                await Task.Delay(waitTime * 1000);
            }
            logger.LogInformation("Finished sending {total} messages with {time}s interval with {batch} messages in batch", payloadLimit, waitTime, batchSize);

            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(list);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}