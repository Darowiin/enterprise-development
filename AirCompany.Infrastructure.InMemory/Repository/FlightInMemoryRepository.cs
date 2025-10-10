using AirCompany.Domain.Fixture;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

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