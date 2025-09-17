using AirCompany.Domain.Models;

namespace AirCompany.Tests.Fixtures;

public class AirCompanyFixture
{
    public List<AircraftFamily> Families { get; } = [];
    public List<AircraftModel> Models { get; } = [];
    public List<Flight> Flights { get; } = [];
    public List<Passenger> Passengers { get; } = [];
    public List<Ticket> Tickets { get; } = [];

    public AirCompanyFixture()
    {
        var airbusFamily = new AircraftFamily { Id = 1, Name = "A320 Family", Manufacturer = "Airbus" };
        var boeingFamily = new AircraftFamily { Id = 2, Name = "737 Family", Manufacturer = "Boeing" };
        var embraerFamily = new AircraftFamily { Id = 3, Name = "E-Jet", Manufacturer = "Embraer" };

        Families.AddRange([airbusFamily, boeingFamily, embraerFamily]);

        var a320Neo = new AircraftModel { Id = 1, ModelName = "A320neo", Family = airbusFamily, FlightRangeKm = 6300, PassengerCapacity = 180, CargoCapacityKg = 20000m };
        var a321Xlr = new AircraftModel { Id = 2, ModelName = "A321XLR", Family = airbusFamily, FlightRangeKm = 8700, PassengerCapacity = 206, CargoCapacityKg = 23000m };
        var b737Max8 = new AircraftModel { Id = 3, ModelName = "737 MAX 8", Family = boeingFamily, FlightRangeKm = 6570, PassengerCapacity = 175, CargoCapacityKg = 19000m };
        var b737Max10 = new AircraftModel { Id = 4, ModelName = "737 MAX 10", Family = boeingFamily, FlightRangeKm = 6100, PassengerCapacity = 188, CargoCapacityKg = 20000m };
        var e190 = new AircraftModel { Id = 5, ModelName = "Embraer 190", Family = embraerFamily, FlightRangeKm = 4400, PassengerCapacity = 100, CargoCapacityKg = 10000m };

        airbusFamily.Models.AddRange([a320Neo, a321Xlr]);
        boeingFamily.Models.AddRange([b737Max8, b737Max10]);
        embraerFamily.Models.Add(e190);

        Models.AddRange([a320Neo, a321Xlr, b737Max8, b737Max10, e190]);

        var flights = new[]
        {
            new Flight { Id = 1, Code = "SU1001", DepartureAirport = "SVO", ArrivalAirport = "LHR", DepartureDateTime = new DateTime(2025, 10, 1, 10, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 1, 14, 0, 0), FlightDuration = TimeSpan.FromHours(4), AircraftModel = a320Neo },
            new Flight { Id = 2, Code = "SU1002", DepartureAirport = "LHR", ArrivalAirport = "SVO", DepartureDateTime = new DateTime(2025, 10, 5, 16, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 5, 20, 0, 0), FlightDuration = TimeSpan.FromHours(4), AircraftModel = a321Xlr },
            new Flight { Id = 3, Code = "BA2001", DepartureAirport = "LHR", ArrivalAirport = "JFK", DepartureDateTime = new DateTime(2025, 10, 2, 8, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 2, 15, 0, 0), FlightDuration = TimeSpan.FromHours(7), AircraftModel = b737Max8 },
            new Flight { Id = 4, Code = "BA2002", DepartureAirport = "JFK", ArrivalAirport = "LHR", DepartureDateTime = new DateTime(2025, 10, 10, 8, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 10, 15, 0, 0), FlightDuration = TimeSpan.FromHours(7), AircraftModel = b737Max8 },
            new Flight { Id = 5, Code = "UT3001", DepartureAirport = "LED", ArrivalAirport = "VKO", DepartureDateTime = new DateTime(2025, 10, 3, 7, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 3, 8, 0, 0), FlightDuration = TimeSpan.FromHours(1), AircraftModel = e190 },
            new Flight { Id = 6, Code = "UT3002", DepartureAirport = "VKO", ArrivalAirport = "LED", DepartureDateTime = new DateTime(2025, 10, 4, 20, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 4, 21, 0, 0), FlightDuration = TimeSpan.FromHours(1), AircraftModel = e190 },
            new Flight { Id = 7, Code = "SU2001", DepartureAirport = "SVO", ArrivalAirport = "DXB", DepartureDateTime = new DateTime(2025, 10, 7, 9, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 7, 14, 0, 0), FlightDuration = TimeSpan.FromHours(5), AircraftModel = a321Xlr },
            new Flight { Id = 8, Code = "SU2002", DepartureAirport = "DXB", ArrivalAirport = "SVO", DepartureDateTime = new DateTime(2025, 10, 12, 12, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 12, 17, 0, 0), FlightDuration = TimeSpan.FromHours(5), AircraftModel = a321Xlr },
            new Flight { Id = 9, Code = "BA3001", DepartureAirport = "LHR", ArrivalAirport = "CDG", DepartureDateTime = new DateTime(2025, 10, 2, 12, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 2, 12, 55, 0), FlightDuration = TimeSpan.FromMinutes(55), AircraftModel = b737Max10 },
            new Flight { Id = 10, Code = "BA3002", DepartureAirport = "CDG", ArrivalAirport = "LHR", DepartureDateTime = new DateTime(2025, 10, 3, 14, 0, 0), ArrivalDateTime = new DateTime(2025, 10, 3, 14, 50, 0), FlightDuration = TimeSpan.FromMinutes(50), AircraftModel = b737Max10 }
        };

        foreach (var flight in flights)
        {
            flight.AircraftModel.Flights.Add(flight);
            Flights.Add(flight);
        }

        Passengers.AddRange(
        [
            new Passenger { Id = 1, PassportNumber = "P100001", FullName = "Иванов Иван Иванович", BirthDate = new DateOnly(1990, 5, 10) },
            new Passenger { Id = 2, PassportNumber = "P100002", FullName = "Петрова Анна Сергеевна", BirthDate = new DateOnly(1985, 3, 21) },
            new Passenger { Id = 3, PassportNumber = "P100003", FullName = "Сидоров Петр Михайлович", BirthDate = new DateOnly(1978, 9, 12) },
            new Passenger { Id = 4, PassportNumber = "P100004", FullName = "Smith John", BirthDate = new DateOnly(1980, 11, 5) },
            new Passenger { Id = 5, PassportNumber = "P100005", FullName = "Brown Alice", BirthDate = new DateOnly(1995, 2, 14) },
            new Passenger { Id = 6, PassportNumber = "P100006", FullName = "Taylor Robert", BirthDate = new DateOnly(1992, 7, 30) },
            new Passenger { Id = 7, PassportNumber = "P100007", FullName = "Kuznetsova Olga", BirthDate = new DateOnly(1988, 6, 9) },
            new Passenger { Id = 8, PassportNumber = "P100008", FullName = "Nguyen Linh", BirthDate = new DateOnly(1999, 12, 1) },
            new Passenger { Id = 9, PassportNumber = "P100009", FullName = "Garcia Maria", BirthDate = new DateOnly(1993, 1, 17) },
            new Passenger { Id = 10, PassportNumber = "P100010", FullName = "Kim Min-ho", BirthDate = new DateOnly(1987, 4, 4) }
        ]);

        AddTicket(1, 1, "1A", true, 15);
        AddTicket(1, 2, "1B", true, 0);
        AddTicket(1, 3, "2A", false, 23);
        AddTicket(1, 4, "2B", true, 0);
        AddTicket(1, 5, "3A", true, 12);

        AddTicket(2, 6, "4C", true, 20);
        AddTicket(2, 7, "4D", true, 0);
        AddTicket(2, 8, "5A", false, 18);

        AddTicket(3, 1, "7B", true, 30);
        AddTicket(3, 5, "8C", false, 0);
        AddTicket(3, 9, "8D", true, 25);
        AddTicket(3, 10, "9A", true, 0);

        AddTicket(5, 2, "10A", false, 0);
        AddTicket(5, 3, "10B", false, 5);
        AddTicket(5, 4, "10C", false, 0);

        AddTicket(9, 8, "11A", true, 10);
        AddTicket(9, 9, "11B", true, 0);
    }

    private void AddTicket(int flightId, int passengerId, string seat, bool handLuggage, decimal? baggage)
    {
        var flight = Flights.Find(f => f.Id == flightId)!;
        var passenger = Passengers.Find(p => p.Id == passengerId)!;

        var ticket = new Ticket
        {
            Id = Tickets.Count + 1,
            Flight = flight,
            Passenger = passenger,
            SeatNumber = seat,
            HasHandLuggage = handLuggage,
            TotalBaggageWeightKg = baggage
        };

        Tickets.Add(ticket);
        flight.Tickets.Add(ticket);
        passenger.Tickets.Add(ticket);
    }
}