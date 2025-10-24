using AirCompany.Domain;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database.Repository;

/// <summary>
/// Repository for managing <see cref="Flight"/> entities in the database.
/// Implements CRUD operations using <see cref="AirCompanyDbContext"/>.
/// </summary>
public class FlightDatabaseRepository(AirCompanyDbContext context) : IRepository<Flight, int>
{
    /// <summary>
    /// Adds a new flight to the database.
    /// </summary>
    /// <param name="entity">The flight to create.</param>
    /// <returns>The created <see cref="Flight"/> entity.</returns>
    public async Task<Flight> Create(Flight entity)
    {
        var result = await context.Flights.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a flight by ID.
    /// </summary>
    /// <param name="entityId">The ID of the flight to delete.</param>
    /// <returns>true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Flights.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a flight by ID.
    /// </summary>
    /// <param name="entityId">The ID of the flight to retrieve.</param>
    /// <returns>The <see cref="Flight"/> entity, or null if not found.</returns>
    public async Task<Flight?> Get(int entityId) =>
        await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all flights.
    /// </summary>
    /// <returns>A list of <see cref="Flight"/> entities.</returns>
    public async Task<IList<Flight>> GetAll() =>
        await context.Flights.ToListAsync();

    /// <summary>
    /// Updates an existing flight.
    /// </summary>
    /// <param name="entity">The flight with updated data.</param>
    /// <returns>The updated <see cref="Flight"/> entity.</returns>
    public async Task<Flight> Update(Flight entity)
    {
        context.Flights.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}