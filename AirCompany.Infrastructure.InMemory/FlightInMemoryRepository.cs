namespace AirCompany.Infrastructure.InMemory;

/// <summary>
/// In-memory repository for <see cref="Flight"/> entities.
/// </summary>
public class FlightInMemoryRepository : InMemoryRepository<Flight>
{
    public FlightInMemoryRepository() : base(AirCompanyFixture.Flights)
    { }
    protected override int GetEntityId(Flight entity) => entity.Id;
    protected override void SetEntityId(Flight entity, int id) => entity.Id = id;
}