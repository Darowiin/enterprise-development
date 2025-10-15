using AirCompany.Domain.Data;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Aircraft Model entities.
/// </summary>
public class AircraftModelInMemoryRepository(DataSeeder seeder) : InMemoryRepository<AircraftModel, int>(seeder.Models)
{
    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected override int GetEntityId(AircraftModel entity) => entity.Id;

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected override void SetEntityId(AircraftModel entity, int id) => entity.Id = id;
}