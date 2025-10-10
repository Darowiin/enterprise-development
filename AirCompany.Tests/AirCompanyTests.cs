using AirCompany.Tests.Fixture;

namespace AirCompany.Tests;

/// <summary>
/// Unit tests for AirCompany using prepopulated fixture data.
/// </summary>
public class AirCompanyTests(AirCompanyFixture fixture) : IClassFixture<AirCompanyFixture>
{
    /// <summary>
    /// Tests that flights are correctly ordered by the number of passengers.
    /// Returns the top 5 flights with the highest passenger count.
    /// </summary>
    [Fact]
    public void GetTopFlightsByPassengerCount_ShouldReturnFlightsOrderedByPassengerCount()
    {
        // Arrange
        var flights = fixture.FlightRepo.GetAll();

        // Act
        var topFlights = flights
            .OrderByDescending(f => f.Tickets!.Count)
            .Take(5)
            .ToList();

        // Assert
        Assert.Equal(5, topFlights.Count);
        for (var i = 0; i < topFlights.Count - 1; i++)
        {
            Assert.True(
                topFlights[i].Tickets!.Count >= topFlights[i + 1].Tickets!.Count,
                $"Flight {topFlights[i].Code} should have >= passengers than {topFlights[i + 1].Code}"
            );
        }
        var maxPassengerCount = flights.Max(f => f.Tickets!.Count);
        Assert.Equal(maxPassengerCount, topFlights.First().Tickets!.Count);
    }

    /// <summary>
    /// Tests retrieval of flights with the minimal flight duration.
    /// Ensures all returned flights have the shortest duration among all flights.
    /// </summary>
    [Fact]
    public void GetFlightsWithMinimalDuration_ShouldReturnFlightsWithShortestDuration()
    {
        // Arrange
        var flights = fixture.FlightRepo.GetAll();

        // Act
        var minDuration = flights.Min(f => f.FlightDuration ?? TimeSpan.MaxValue);
        var flightsWithMinDuration = flights
            .Where(f => f.FlightDuration.HasValue && f.FlightDuration.Value == minDuration)
            .ToList();

        // Assert
        Assert.NotEmpty(flightsWithMinDuration);
        Assert.All(flightsWithMinDuration, f => Assert.Equal(minDuration, f.FlightDuration));
    }

    /// <summary>
    /// Tests retrieval of passengers without checked baggage on a specific flight.
    /// Returns passengers ordered by their full name.
    /// </summary>
    [Fact]
    public void GetPassengersWithZeroBaggageByFlight_ShouldReturnOrderedByName()
    {
        // Arrange
        var selectedFlight = fixture.FlightRepo.GetAll().First(f => f.Code == "SU1001");

        // Act
        var passengersWithNoBaggage = selectedFlight.Tickets!
            .Where(t => t.TotalBaggageWeightKg is null or 0)
            .Select(t => t.Passenger)
            .OrderBy(p => p.FullName, StringComparer.Ordinal)
            .ToList();

        var expectedOrder = new[]
        {
            "Ivanov Ivan Ivanovich",
            "Petrova Anna Sergeevna"
        };

        // Assert
        Assert.Equal(expectedOrder, passengersWithNoBaggage.Select(p => p.FullName).ToArray());
    }

    /// <summary>
    /// Tests retrieval of flights for a given aircraft model within a specific date range.
    /// Ensures all returned flights match the model and period.
    /// </summary>
    [Fact]
    public void GetFlightsByModelAndPeriod_ShouldReturnOnlyMatchingFlights()
    {
        // Arrange
        var selectedModel = fixture.ModelRepo.GetAll().First();
        var startDate = new DateTime(2025, 10, 1);
        var endDate = new DateTime(2025, 10, 31);
        var flights = fixture.FlightRepo.GetAll();

        // Act
        var flightsInPeriod = flights
            .Where(f => f.AircraftModel == selectedModel &&
                        f.DepartureDateTime.HasValue &&
                        f.DepartureDateTime.Value >= startDate &&
                        f.DepartureDateTime.Value <= endDate)
            .ToList();

        // Assert
        Assert.All(flightsInPeriod, f =>
        {
            Assert.Equal(selectedModel, f.AircraftModel);
            Assert.InRange(f.DepartureDateTime!.Value, startDate, endDate);
        });
    }

    /// <summary>
    /// Tests retrieval of flights by a specific departure and arrival airport.
    /// Ensures all returned flights match the requested route.
    /// </summary>
    [Fact]
    public void GetFlightsByRoute_ShouldReturnFlightsWithMatchingDepartureAndArrival()
    {
        // Arrange
        var departure = "SVO";
        var arrival = "LHR";
        var flights = fixture.FlightRepo.GetAll();

        // Act
        var flightsByRoute = flights
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .ToList();

        // Assert
        Assert.All(flightsByRoute, f =>
        {
            Assert.Equal(departure, f.DepartureAirport);
            Assert.Equal(arrival, f.ArrivalAirport);
        });
    }
}