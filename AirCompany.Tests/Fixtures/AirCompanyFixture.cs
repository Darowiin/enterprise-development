using AirCompany.Domain.Models;

namespace AirCompany.Tests.Fixtures;

/// <summary>
/// Fixture for testing the airline company.
/// Initializes a set of data: aircraft families, models, flights, passengers, and tickets.
/// Used for unit tests with predefined data.
/// </summary>
public class AirCompanyFixture
{
    /// <summary>
    /// List of aircraft families (AircraftFamily).
    /// </summary>
    public List<AircraftFamily> Families { get; } = [];

    /// <summary>
    /// List of aircraft models (AircraftModel).
    /// </summary>
    public List<AircraftModel> Models { get; } = [];

    /// <summary>
    /// List of flights (Flight).
    /// </summary>
    public List<Flight> Flights { get; } = [];

    /// <summary>
    /// List of passengers (Passenger).
    /// </summary>
    public List<Passenger> Passengers { get; } = [];

    /// <summary>
    /// List of tickets (Ticket), linking passengers to flights.
    /// </summary>
    public List<Ticket> Tickets { get; } = [];

    /// <summary>
    /// Constructor initializes the fixture with predefined data.
    /// Adds aircraft families, models, flights, passengers, and tickets.
    /// </summary>
    public AirCompanyFixture()
    {
        Families.AddRange(
        [
            new AircraftFamily { Id = 1, Name = "A320 Family", Manufacturer = "Airbus" },
            new AircraftFamily { Id = 2, Name = "B737 Family", Manufacturer = "Boeing" },
            new AircraftFamily { Id = 3, Name = "E-Jet Family", Manufacturer = "Embraer" },
            new AircraftFamily { Id = 4, Name = "A330 Family", Manufacturer = "Airbus" },
            new AircraftFamily { Id = 5, Name = "B787 Family", Manufacturer = "Boeing" },
            new AircraftFamily { Id = 6, Name = "A350 Family", Manufacturer = "Airbus" },
            new AircraftFamily { Id = 7, Name = "CRJ Family", Manufacturer = "Bombardier" },
            new AircraftFamily { Id = 8, Name = "Regional Jet Family", Manufacturer = "Sukhoi" },
            new AircraftFamily { Id = 9, Name = "B777 Family", Manufacturer = "Boeing" },
            new AircraftFamily { Id = 10, Name = "SSJ Family", Manufacturer = "Sukhoi" }
        ]);

        Models.AddRange(
        [
            new AircraftModel { Id = 1, ModelName = "A320neo", Family = Families[0], FlightRangeKm = 6300, PassengerCapacity = 180, CargoCapacityKg = 20000m },
            new AircraftModel { Id = 2, ModelName = "A321XLR", Family = Families[0], FlightRangeKm = 8700, PassengerCapacity = 206, CargoCapacityKg = 23000m },
            new AircraftModel { Id = 3, ModelName = "737MAX8", Family = Families[1], FlightRangeKm = 6570, PassengerCapacity = 175, CargoCapacityKg = 19000m },
            new AircraftModel { Id = 4, ModelName = "737MAX10", Family = Families[1], FlightRangeKm = 6100, PassengerCapacity = 188, CargoCapacityKg = 20000m },
            new AircraftModel { Id = 5, ModelName = "E190", Family = Families[2], FlightRangeKm = 4400, PassengerCapacity = 100, CargoCapacityKg = 10000m },
            new AircraftModel { Id = 6, ModelName = "E195-E2", Family = Families[2], FlightRangeKm = 4800, PassengerCapacity = 124, CargoCapacityKg = 11000m },
            new AircraftModel { Id = 7, ModelName = "A330-300", Family = Families[3], FlightRangeKm = 11500, PassengerCapacity = 277, CargoCapacityKg = 45000m },
            new AircraftModel { Id = 8, ModelName = "B787-8", Family = Families[4], FlightRangeKm = 13600, PassengerCapacity = 242, CargoCapacityKg = 50000m },
            new AircraftModel { Id = 9, ModelName = "A350-900", Family = Families[5], FlightRangeKm = 15000, PassengerCapacity = 300, CargoCapacityKg = 60000m },
            new AircraftModel { Id = 10, ModelName = "CRJ900", Family = Families[6], FlightRangeKm = 2900, PassengerCapacity = 90, CargoCapacityKg = 8000m }
        ]);

        foreach (var model in Models)
        {
            model.Family.Models.Add(model);
        }

        Flights.AddRange(
        [
            new Flight { Id = 1, Code = "SU1001", DepartureAirport = "SVO", ArrivalAirport = "LHR",
                DepartureDateTime = new DateTime(2025,10,1,10,0,0), ArrivalDateTime = new DateTime(2025,10,1,12,0,0),
                FlightDuration = TimeSpan.FromHours(2), AircraftModel = Models[0] },
            new Flight { Id = 2, Code = "SU1002", DepartureAirport = "SVO", ArrivalAirport = "JFK",
                DepartureDateTime = new DateTime(2025,10,2,15,0,0), ArrivalDateTime = new DateTime(2025,10,2,21,0,0),
                FlightDuration = TimeSpan.FromHours(6), AircraftModel = Models[1] },
            new Flight { Id = 3, Code = "SU1003", DepartureAirport = "LED", ArrivalAirport = "CDG",
                DepartureDateTime = new DateTime(2025,10,3,9,0,0), ArrivalDateTime = new DateTime(2025,10,3,12,0,0),
                FlightDuration = TimeSpan.FromHours(3), AircraftModel = Models[2] },
            new Flight { Id = 4, Code = "SU1004", DepartureAirport = "VKO", ArrivalAirport = "DXB",
                DepartureDateTime = new DateTime(2025,10,4,14,0,0), ArrivalDateTime = new DateTime(2025,10,4,20,0,0), 
                FlightDuration = TimeSpan.FromHours(6), AircraftModel = Models[3] },
            new Flight { Id = 5, Code = "SU1005", DepartureAirport = "SVO", ArrivalAirport = "SIN", 
                DepartureDateTime = new DateTime(2025,10,5,22,0,0), ArrivalDateTime = new DateTime(2025,10,6,6,0,0), 
                FlightDuration = TimeSpan.FromHours(8), AircraftModel = Models[4] },
            new Flight { Id = 6, Code = "SU1006", DepartureAirport = "SVO", ArrivalAirport = "HND", 
                DepartureDateTime = new DateTime(2025,10,6,6,0,0), ArrivalDateTime = new DateTime(2025,10,6,15,0,0), 
                FlightDuration = TimeSpan.FromHours(9), AircraftModel = Models[5] },
            new Flight { Id = 7, Code = "SU1007", DepartureAirport = "LED", ArrivalAirport = "BER", 
                DepartureDateTime = new DateTime(2025,10,7,11,0,0), ArrivalDateTime = new DateTime(2025,10,7,13,0,0), 
                FlightDuration = TimeSpan.FromHours(2), AircraftModel = Models[6] },
            new Flight { Id = 8, Code = "SU1008", DepartureAirport = "SVO", ArrivalAirport = "LHR", 
                DepartureDateTime = new DateTime(2025,10,8,16,0,0), ArrivalDateTime = new DateTime(2025,10,8,18,0,0), 
                FlightDuration = TimeSpan.FromHours(2), AircraftModel = Models[7] },
            new Flight { Id = 9, Code = "SU1009", DepartureAirport = "VKO", ArrivalAirport = "CDG", 
                DepartureDateTime = new DateTime(2025,10,9,8,0,0), ArrivalDateTime = new DateTime(2025,10,9,11,0,0),
                FlightDuration = TimeSpan.FromHours(3), AircraftModel = Models[8] },
            new Flight { Id = 10, Code = "SU1010", DepartureAirport = "SVO", ArrivalAirport = "JFK", 
                DepartureDateTime = new DateTime(2025,10,10,7,0,0), ArrivalDateTime = new DateTime(2025,10,10,13,0,0),
                FlightDuration = TimeSpan.FromHours(6), AircraftModel = Models[9] }
        ]);

        Passengers.AddRange(
        [
            new Passenger { Id = 1, PassportNumber="P100001", FullName="Иванов Иван Иванович", BirthDate=new DateOnly(1985,1,10) },
            new Passenger { Id = 2, PassportNumber="P100002", FullName="Петрова Анна Сергеевна", BirthDate=new DateOnly(1990,5,22) },
            new Passenger { Id = 3, PassportNumber="P100003", FullName="Сидоров Петр М.", BirthDate=new DateOnly(1978,3,15) },
            new Passenger { Id = 4, PassportNumber="P100004", FullName="Smith John", BirthDate=new DateOnly(1988,11,2) },
            new Passenger { Id = 5, PassportNumber="P100005", FullName="Brown Alice", BirthDate=new DateOnly(1992,7,7) },
            new Passenger { Id = 6, PassportNumber="P100006", FullName="Taylor Robert", BirthDate=new DateOnly(1983,12,12) },
            new Passenger { Id = 7, PassportNumber="P100007", FullName="Lee Kevin", BirthDate=new DateOnly(1995,2,28) },
            new Passenger { Id = 8, PassportNumber="P100008", FullName="Kuznetsova Olga", BirthDate=new DateOnly(1987,6,19) },
            new Passenger { Id = 9, PassportNumber="P100009", FullName="Nguyen Linh", BirthDate=new DateOnly(1991,9,5) },
            new Passenger { Id = 10, PassportNumber="P100010", FullName="Garcia Maria", BirthDate=new DateOnly(1989,8,23) },
            new Passenger { Id = 11, PassportNumber="P100011", FullName="Schmidt Hans", BirthDate=new DateOnly(1975,4,1) },
            new Passenger { Id = 12, PassportNumber="P100012", FullName="Dubois Pierre", BirthDate=new DateOnly(1982,10,14) },
            new Passenger { Id = 13, PassportNumber = "P100013", FullName = "Rossi Marco", BirthDate = new DateOnly(1986, 3, 17) },
            new Passenger { Id = 14, PassportNumber = "P100014", FullName = "Silva Ana", BirthDate = new DateOnly(1993, 12, 25) },
            new Passenger { Id = 15, PassportNumber = "P100015", FullName = "Novak Petra", BirthDate = new DateOnly(1990, 5, 5) },
            new Passenger { Id = 16, PassportNumber = "P100016", FullName = "Kowalski Jan", BirthDate = new DateOnly(1981, 9, 30) },
            new Passenger { Id = 17, PassportNumber = "P100017", FullName = "Popov Ivan", BirthDate = new DateOnly(1984, 11, 11) },
            new Passenger { Id = 18, PassportNumber = "P100018", FullName = "Hernandez Luis", BirthDate = new DateOnly(1989, 1, 20) },
            new Passenger { Id = 19, PassportNumber = "P100019", FullName = "Singh Raj", BirthDate = new DateOnly(1992, 2, 2) },
            new Passenger { Id = 20, PassportNumber = "P100020", FullName = "Wang Li", BirthDate = new DateOnly(1986, 7, 15) },
            new Passenger { Id = 21, PassportNumber = "P100021", FullName = "Muller Eva", BirthDate = new DateOnly(1988, 6, 30) },
            new Passenger { Id = 22, PassportNumber = "P100022", FullName = "Nowak Adam", BirthDate = new DateOnly(1985, 8, 19) },
            new Passenger { Id = 23, PassportNumber = "P100023", FullName = "Ivanova L.", BirthDate = new DateOnly(1991, 3, 27) },
            new Passenger { Id = 24, PassportNumber = "P100024", FullName = "Petrov P.", BirthDate = new DateOnly(1987, 10, 8) },
            new Passenger { Id = 25, PassportNumber = "P100025", FullName = "Gonzalez M.", BirthDate = new DateOnly(1980, 12, 12) },
            new Passenger { Id = 26, PassportNumber = "P100026", FullName = "Anderson L.", BirthDate = new DateOnly(1983, 5, 17) },
            new Passenger { Id = 27, PassportNumber = "P100027", FullName = "O'Neil K.", BirthDate = new DateOnly(1979, 11, 23) },
            new Passenger { Id = 28, PassportNumber = "P100028", FullName = "Martinez C.", BirthDate = new DateOnly(1994, 4, 2) },
            new Passenger { Id = 29, PassportNumber = "P100029", FullName = "Sato Y.", BirthDate = new DateOnly(1985, 9, 12) },
            new Passenger { Id = 30, PassportNumber = "P100030", FullName = "Petrova M.", BirthDate = new DateOnly(1989, 6, 6) }
        ]);

        var ticketId = 1;
        /// <summary>
        /// Creates a ticket for a given flight and passenger, and updates the respective collections.
        /// </summary>
        /// <param name="flightIndex">Index of the flight in the Flights list.</param>
        /// <param name="passengerIndex">Index of the passenger in the Passengers list.</param>
        /// <param name="seat">Seat number assigned to the ticket.</param>
        /// <param name="handLuggage">Indicates whether the passenger has hand luggage.</param>
        /// <param name="baggageWeight">Weight of checked baggage, if any.</param>
        void AddTicket(int flightIndex, int passengerIndex, string seat, bool handLuggage, decimal? baggageWeight)
        {
            var flight = Flights[flightIndex];
            var passenger = Passengers[passengerIndex];
            var ticket = new Ticket
            {
                Id = ticketId++,
                Flight = flight,
                Passenger = passenger,
                SeatNumber = seat,
                HasHandLuggage = handLuggage,
                TotalBaggageWeightKg = baggageWeight
            };
            Tickets.Add(ticket);
            flight.Tickets.Add(ticket);
            passenger.Tickets.Add(ticket);
        }

        AddTicket(0, 0, "12A", true, 0);
        AddTicket(0, 1, "12B", true, 0);
        AddTicket(0, 2, "13C", true, 15);
        AddTicket(0, 3, "12C", true, 15);
        AddTicket(1, 4, "14A", true, 20);
        AddTicket(1, 5, "14B", true, 0);
        AddTicket(1, 6, "14C", false, 25);
        AddTicket(2, 7, "10A", true, 0);
        AddTicket(2, 8, "10B", true, 10);
        AddTicket(2, 9, "10C", false, 0);
        AddTicket(3, 10, "15A", true, 12);
        AddTicket(3, 11, "15B", true, 0);
        AddTicket(3, 12, "15C", false, 8);
        AddTicket(4, 13, "16A", true, 5);
        AddTicket(4, 14, "16B", true, 0);
        AddTicket(4, 15, "16C", false, 20);
        AddTicket(5, 16, "17A", true, 0);
        AddTicket(5, 17, "17B", true, 25);
        AddTicket(5, 18, "17C", false, 0);
        AddTicket(6, 19, "18A", true, 0);
        AddTicket(6, 20, "18B", true, 5);
        AddTicket(6, 21, "18C", false, 0);
        AddTicket(7, 22, "19A", true, 10);
        AddTicket(7, 23, "19B", true, 0);
        AddTicket(7, 24, "19C", false, 8);
        AddTicket(8, 25, "20A", true, 0);
        AddTicket(8, 26, "20B", true, 10);
        AddTicket(8, 27, "20C", false, 0);
        AddTicket(9, 28, "21A", true, 0);
        AddTicket(9, 29, "21B", true, 15);
    }
}