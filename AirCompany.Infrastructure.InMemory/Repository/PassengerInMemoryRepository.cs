using AirCompany.Domain.Data;
using AirCompany.Domain.Model;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// In-memory repository for Passenger entities.
/// </summary>
public class PassengerInMemoryRepository(DataSeeder seeder) : InMemoryRepository<Passenger, int>(seeder.Passengers)
{
    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected override int GetEntityId(Passenger entity) => entity.Id;

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected override void SetEntityId(Passenger entity, int id) => entity.Id = id;
}