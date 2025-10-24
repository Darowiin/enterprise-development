using AirCompany.Domain;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database.Repository;

/// <summary>
/// Repository for managing <see cref="AircraftFamily"/> entities in the database.
/// Implements CRUD operations using <see cref="AirCompanyDbContext"/>.
/// </summary>
public class AircraftFamilyDatabaseRepository(AirCompanyDbContext context) : IRepository<AircraftFamily, int>
{
    /// <summary>
    /// Adds a new aircraft family to the database.
    /// </summary>
    /// <param name="entity">The aircraft family to create.</param>
    /// <returns>The created <see cref="AircraftFamily"/> entity.</returns>
    public async Task<AircraftFamily> Create(AircraftFamily entity)
    {
        var result = await context.AircraftFamilies.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes an aircraft family by ID.
    /// </summary>
    /// <param name="entityId">The ID of the aircraft family to delete.</param>
    /// <returns>true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.AircraftFamilies.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.AircraftFamilies.Remove(entity);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Retrieves an aircraft family by ID.
    /// </summary>
    /// <param name="entityId">The ID of the aircraft family to retrieve.</param>
    /// <returns>The <see cref="AircraftFamily"/> entity, or null if not found.</returns>
    public async Task<AircraftFamily?> Get(int entityId) =>
        await context.AircraftFamilies.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all aircraft families.
    /// </summary>
    /// <returns>A list of <see cref="AircraftFamily"/> entities.</returns>
    public async Task<IList<AircraftFamily>> GetAll() =>
        await context.AircraftFamilies.ToListAsync();

    /// <summary>
    /// Updates an existing aircraft family.
    /// </summary>
    /// <param name="entity">The aircraft family with updated data.</param>
    /// <returns>The updated <see cref="AircraftFamily"/> entity.</returns>
    public async Task<AircraftFamily> Update(AircraftFamily entity)
    {
        context.AircraftFamilies.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}