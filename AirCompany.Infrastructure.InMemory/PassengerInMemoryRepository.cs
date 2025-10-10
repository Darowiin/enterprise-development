namespace AirCompany.Infrastructure.InMemory;

/// <summary>
/// In-memory repository for <see cref="Passenger"/> entities.
/// </summary>
public class PassengerInMemoryRepository : InMemoryRepository<Passenger>
{
    public PassengerInMemoryRepository() : base(AirCompanyFixture.Passengers)
    { }
    protected override int GetEntityId(Passenger entity) => entity.Id;
    protected override void SetEntityId(Passenger entity, int id) => entity.Id = id;
}
