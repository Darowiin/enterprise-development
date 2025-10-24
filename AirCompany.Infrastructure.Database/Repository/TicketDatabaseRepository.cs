using AirCompany.Domain;
using AirCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Database.Repository;

/// <summary>
/// Repository for managing <see cref="Ticket"/> entities in the database.
/// Implements CRUD operations using <see cref="AirCompanyDbContext"/>.
/// </summary>
public class TicketDatabaseRepository(AirCompanyDbContext context) : IRepository<Ticket, int>
{
    /// <summary>
    /// Adds a new ticket to the database.
    /// </summary>
    /// <param name="entity">The ticket to create.</param>
    /// <returns>The created <see cref="Ticket"/> entity.</returns>
    public async Task<Ticket> Create(Ticket entity)
    {
        var result = await context.Tickets.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a ticket by ID.
    /// </summary>
    /// <param name="entityId">The ID of the ticket to delete.</param>
    /// <returns>true if the deletion was successful; otherwise, false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Tickets.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves a ticket by ID.
    /// </summary>
    /// <param name="entityId">The ID of the ticket to retrieve.</param>
    /// <returns>The <see cref="Ticket"/> entity, or null if not found.</returns>
    public async Task<Ticket?> Get(int entityId) =>
        await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Retrieves all tickets.
    /// </summary>
    /// <returns>A list of <see cref="Ticket"/> entities.</returns>
    public async Task<IList<Ticket>> GetAll() =>
        await context.Tickets.ToListAsync();

    /// <summary>
    /// Updates an existing ticket.
    /// </summary>
    /// <param name="entity">The ticket with updated data.</param>
    /// <returns>The updated <see cref="Ticket"/> entity.</returns>
    public async Task<Ticket> Update(Ticket entity)
    {
        context.Tickets.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
