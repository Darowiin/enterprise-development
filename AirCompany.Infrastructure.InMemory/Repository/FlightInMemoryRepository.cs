using AirCompany.Domain.Data;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Flight entities.
/// </summary>
public class FlightInMemoryRepository(DataSeeder seeder) : InMemoryRepository<Flight, int>(seeder.Flights)
{
    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected override int GetEntityId(Flight entity) => entity.Id;

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected override void SetEntityId(Flight entity, int id) => entity.Id = id;
}