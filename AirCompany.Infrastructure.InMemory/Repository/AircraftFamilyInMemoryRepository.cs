using AirCompany.Domain.Data;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Aircraft Family entities.
/// </summary>
public class AircraftFamilyInMemoryRepository(DataSeeder seeder) : InMemoryRepository<AircraftFamily, int>(seeder.Families)
{
    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected override int GetEntityId(AircraftFamily entity) => entity.Id;

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected override void SetEntityId(AircraftFamily entity, int id) => entity.Id = id;
}