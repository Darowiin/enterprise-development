namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Flight entities.
/// </summary>
public class FlightInMemoryRepository : InMemoryRepository<Flight>
{
    public FlightInMemoryRepository(DataSeeder seeder) : base(seeder.Flights) { }
    protected override int GetEntityId(Flight entity) => entity.Id;
    protected override void SetEntityId(Flight entity, int id) => entity.Id = id;
}