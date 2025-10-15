using AirCompany.Domain.Data;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Ticket entities.
/// </summary>
public class TicketInMemoryRepository(DataSeeder seeder) : InMemoryRepository<Ticket, int>(seeder.Tickets)
{
    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected override int GetEntityId(Ticket entity) => entity.Id;

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected override void SetEntityId(Ticket entity, int id) => entity.Id = id;
}