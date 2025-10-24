using AirCompany.Domain;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database.Repository;

/// <summary>
/// Repository for managing <see cref="Passenger"/> entities in the database.
/// Implements CRUD operations using <see cref="AirCompanyDbContext"/>.
/// </summary>
public class PassengerDatabaseRepository(AirCompanyDbContext context) : IRepository<Passenger, int>
{
    /// <summary>
    /// Adds a new passenger to the database.
    /// </summary>
    /// <param name="entity">The passenger to create.</param>
    /// <returns>The created <see cref="Passenger"/> entity.</returns>
    public async Task<Passenger> Create(Passenger entity)
    {
        var result = await context.Passengers.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a passenger by ID.
    /// </summary>
    /// <param name="entityId">The ID of the passenger to delete.</param>
    /// <returns>true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Passengers.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a passenger by ID.
    /// </summary>
    /// <param name="entityId">The ID of the passenger to retrieve.</param>
    /// <returns>The <see cref="Passenger"/> entity, or null if not found.</returns>
    public async Task<Passenger?> Get(int entityId) =>
        await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all passengers.
    /// </summary>
    /// <returns>A list of <see cref="Passenger"/> entities.</returns>
    public async Task<IList<Passenger>> GetAll() =>
        await context.Passengers.ToListAsync();

    /// <summary>
    /// Updates an existing passenger.
    /// </summary>
    /// <param name="entity">The passenger with updated data.</param>
    /// <returns>The updated <see cref="Passenger"/> entity.</returns>
    public async Task<Passenger> Update(Passenger entity)
    {
        context.Passengers.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}