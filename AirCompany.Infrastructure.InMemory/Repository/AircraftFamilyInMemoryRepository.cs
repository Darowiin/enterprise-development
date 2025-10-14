using AirCompany.Domain.Data;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Aircraft Family entities.
/// </summary>
public class AircraftFamilyInMemoryRepository : InMemoryRepository<AircraftFamily>
{
    public AircraftFamilyInMemoryRepository(DataSeeder seeder) : base(seeder.Families) { }
    protected override int GetEntityId(AircraftFamily entity) => entity.Id;
    protected override void SetEntityId(AircraftFamily entity, int id) => entity.Id = id;
}