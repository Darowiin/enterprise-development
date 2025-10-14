namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Passenger entities.
/// </summary>
public class PassengerInMemoryRepository : InMemoryRepository<Passenger>
{
    public PassengerInMemoryRepository(DataSeeder seeder) : base(seeder.Passengers) { }
    protected override int GetEntityId(Passenger entity) => entity.Id;
    protected override void SetEntityId(Passenger entity, int id) => entity.Id = id;
}