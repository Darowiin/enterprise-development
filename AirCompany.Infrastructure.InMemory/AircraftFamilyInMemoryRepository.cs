namespace AirCompany.Infrastructure.InMemory;

/// <summary>
/// In-memory repository for <see cref="AircraftFamily"/> entities.
/// </summary>
public class AircraftFamilyInMemoryRepository : InMemoryRepository<AircraftFamily>
{
    public AircraftFamilyInMemoryRepository() : base(AirCompanyFixture.Families)
    { }
    protected override int GetEntityId(AircraftFamily entity) => entity.Id;
    protected override void SetEntityId(AircraftFamily entity, int id) => entity.Id = id;
}