using AirCompany.Domain.Fixture;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for <see cref="Ticket"/> entities.
/// </summary>
public class TicketInMemoryRepository : InMemoryRepository<Ticket>
{
    public TicketInMemoryRepository() : base(AirCompanyFixture.Tickets)
    { }
    protected override int GetEntityId(Ticket entity) => entity.Id;
    protected override void SetEntityId(Ticket entity, int id) => entity.Id = id;
}