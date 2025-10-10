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
        _ = new DataSeeder();

        PassengerRepo = new PassengerInMemoryRepository(DataSeeder.Passengers);
        FlightRepo = new FlightInMemoryRepository(DataSeeder.Flights);
        TicketRepo = new TicketInMemoryRepository(DataSeeder.Tickets);
        FamilyRepo = new AircraftFamilyInMemoryRepository(DataSeeder.Families);
        ModelRepo = new AircraftModelInMemoryRepository(DataSeeder.Models);
    }
}