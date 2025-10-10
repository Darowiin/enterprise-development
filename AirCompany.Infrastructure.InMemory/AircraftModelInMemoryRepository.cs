namespace AirCompany.Infrastructure.InMemory;

/// <summary>
/// In-memory repository for <see cref="AircraftModel"/> entities.
/// </summary>
public class AircraftModelInMemoryRepository : InMemoryRepository<AircraftModel>
{
    public AircraftModelInMemoryRepository() : base(AirCompanyFixture.Models)
    { }
    protected override int GetEntityId(AircraftModel entity) => entity.Id;
    protected override void SetEntityId(AircraftModel entity, int id) => entity.Id = id;
}