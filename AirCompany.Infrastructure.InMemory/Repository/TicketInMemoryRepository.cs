namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Ticket entities.
/// </summary>
public class TicketInMemoryRepository : InMemoryRepository<Ticket>
{
    public TicketInMemoryRepository(List<Ticket> entities) : base(entities) { }
    protected override int GetEntityId(Ticket entity) => entity.Id;
    protected override void SetEntityId(Ticket entity, int id) => entity.Id = id;
}