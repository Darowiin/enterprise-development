using AirCompany.Domain.Data;
using AirCompany.Infrastructure.InMemory.Repository;

namespace AirCompany.Tests.Fixture;

/// <summary>
/// Fixture for unit tests.
/// Initializes repositories with prepopulated data from <see cref="DataSeeder"/>.
/// </summary>
public class AirCompanyFixture
{
    public PassengerInMemoryRepository PassengerRepo { get; }
    public FlightInMemoryRepository FlightRepo { get; }
    public TicketInMemoryRepository TicketRepo { get; }
    public AircraftFamilyInMemoryRepository FamilyRepo { get; }
    public AircraftModelInMemoryRepository ModelRepo { get; }

    /// <summary>
    /// Initializes the fixture and repositories with seeded data.
    /// </summary>
    public AirCompanyFixture()
    {
        var seeder = new DataSeeder();

        PassengerRepo = new PassengerInMemoryRepository(seeder);
        FlightRepo = new FlightInMemoryRepository(seeder);
        TicketRepo = new TicketInMemoryRepository(seeder);
        FamilyRepo = new AircraftFamilyInMemoryRepository(seeder);
        ModelRepo = new AircraftModelInMemoryRepository(seeder);
    }
}