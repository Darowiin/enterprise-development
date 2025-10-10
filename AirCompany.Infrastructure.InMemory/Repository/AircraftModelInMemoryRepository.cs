namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Aircraft Model entities.
/// </summary>
public class AircraftModelInMemoryRepository : InMemoryRepository<AircraftModel>
{
    public AircraftModelInMemoryRepository(List<AircraftModel> entities) : base(entities) { }
    protected override int GetEntityId(AircraftModel entity) => entity.Id;
    protected override void SetEntityId(AircraftModel entity, int id) => entity.Id = id;
}