using AirCompany.Domain;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database.Repository;

/// <summary>
/// Repository for managing <see cref="AircraftModel"/> entities in the database.
/// Implements CRUD operations using <see cref="AirCompanyDbContext"/>.
/// </summary>
public class AircraftModelDatabaseRepository(AirCompanyDbContext context) : IRepository<AircraftModel, int>
{
    /// <summary>
    /// Adds a new aircraft model to the database.
    /// </summary>
    /// <param name="entity">The aircraft model to create.</param>
    /// <returns>The created <see cref="AircraftModel"/> entity.</returns>
    public async Task<AircraftModel> Create(AircraftModel entity)
    {
        var result = await context.AircraftModels.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes an aircraft model by ID.
    /// </summary>
    /// <param name="entityId">The ID of the aircraft model to delete.</param>
    /// <returns>true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.AircraftModels.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.AircraftModels.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves an aircraft model by ID.
    /// </summary>
    /// <param name="entityId">The ID of the aircraft model to retrieve.</param>
    /// <returns>The <see cref="AircraftFamily"/> entity, or null if not found.</returns>
    public async Task<AircraftModel?> Get(int entityId) =>
        await context.AircraftModels.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all aircraft models.
    /// </summary>
    /// <returns>A list of <see cref="AircraftModel"/> entities.</returns>
    public async Task<IList<AircraftModel>> GetAll() =>
        await context.AircraftModels.ToListAsync();

    /// <summary>
    /// Updates an existing aircraft model.
    /// </summary>
    /// <param name="entity">The aircraft model with updated data.</param>
    /// <returns>The updated <see cref="AircraftModel"/> entity.</returns>
    public async Task<AircraftModel> Update(AircraftModel entity)
    {
        context.AircraftModels.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}