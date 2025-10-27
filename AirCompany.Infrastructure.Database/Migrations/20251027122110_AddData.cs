using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirCompany.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AircraftFamilies",
            columns: new[] { "Id", "Manufacturer", "Name" },
            values: new object[,]
            {
                { 1, "Airbus", "A320 Family" },
                { 2, "Boeing", "B737 Family" },
                { 3, "Embraer", "E-Jet Family" },
                { 4, "Airbus", "A330 Family" },
                { 5, "Boeing", "B787 Family" },
                { 6, "Airbus", "A350 Family" },
                { 7, "Bombardier", "CRJ Family" },
                { 8, "Sukhoi", "Regional Jet Family" },
                { 9, "Boeing", "B777 Family" },
                { 10, "Sukhoi", "SSJ Family" }
            });

        migrationBuilder.InsertData(
            table: "Passengers",
            columns: new[] { "Id", "BirthDate", "FullName", "PassportNumber" },
            values: new object[,]
            {
                { 1, new DateOnly(1985, 1, 10), "Ivanov Ivan Ivanovich", "P100001" },
                { 2, new DateOnly(1990, 5, 22), "Petrova Anna Sergeevna", "P100002" },
                { 3, new DateOnly(1978, 3, 15), "Sidorov Peter Maximovich", "P100003" },
                { 4, new DateOnly(1988, 11, 2), "Smith John", "P100004" },
                { 5, new DateOnly(1992, 7, 7), "Brown Alice", "P100005" },
                { 6, new DateOnly(1983, 12, 12), "Taylor Robert", "P100006" },
                { 7, new DateOnly(1995, 2, 28), "Lee Kevin", "P100007" },
                { 8, new DateOnly(1987, 6, 19), "Kuznetsova Olga", "P100008" },
                { 9, new DateOnly(1991, 9, 5), "Nguyen Linh", "P100009" },
                { 10, new DateOnly(1989, 8, 23), "Garcia Maria", "P100010" },
                { 11, new DateOnly(1975, 4, 1), "Schmidt Hans", "P100011" },
                { 12, new DateOnly(1982, 10, 14), "Dubois Pierre", "P100012" },
                { 13, new DateOnly(1986, 3, 17), "Rossi Marco", "P100013" },
                { 14, new DateOnly(1993, 12, 25), "Silva Ana", "P100014" },
                { 15, new DateOnly(1990, 5, 5), "Novak Petra", "P100015" },
                { 16, new DateOnly(1981, 9, 30), "Kowalski Jan", "P100016" },
                { 17, new DateOnly(1984, 11, 11), "Popov Ivan", "P100017" },
                { 18, new DateOnly(1989, 1, 20), "Hernandez Luis", "P100018" },
                { 19, new DateOnly(1992, 2, 2), "Singh Raj", "P100019" },
                { 20, new DateOnly(1986, 7, 15), "Wang Li", "P100020" },
                { 21, new DateOnly(1988, 6, 30), "Muller Eva", "P100021" },
                { 22, new DateOnly(1985, 8, 19), "Nowak Adam", "P100022" },
                { 23, new DateOnly(1991, 3, 27), "Ivanova L.", "P100023" },
                { 24, new DateOnly(1987, 10, 8), "Petrov P.", "P100024" },
                { 25, new DateOnly(1980, 12, 12), "Gonzalez M.", "P100025" },
                { 26, new DateOnly(1983, 5, 17), "Anderson L.", "P100026" },
                { 27, new DateOnly(1979, 11, 23), "O'Neil K.", "P100027" },
                { 28, new DateOnly(1994, 4, 2), "Martinez C.", "P100028" },
                { 29, new DateOnly(1985, 9, 12), "Sato Y.", "P100029" },
                { 30, new DateOnly(1989, 6, 6), "Petrova M.", "P100030" }
            });

        migrationBuilder.InsertData(
            table: "AircraftModels",
            columns: new[] { "Id", "CargoCapacityKg", "FamilyId", "FlightRangeKm", "ModelName", "PassengerCapacity" },
            values: new object[,]
            {
                { 1, 20000.0, 1, 6300.0, "A320neo", 180 },
                { 2, 23000.0, 1, 8700.0, "A321XLR", 206 },
                { 3, 19000.0, 2, 6500.0, "737MAX8", 175 },
                { 4, 20000.0, 2, 5950.0, "737MAX10", 188 },
                { 5, 10000.0, 3, 4400.0, "E190", 100 },
                { 6, 11000.0, 3, 4800.0, "E195-E2", 124 },
                { 7, 45000.0, 4, 11500.0, "A330-300", 277 },
                { 8, 50000.0, 5, 13600.0, "B787-8", 242 },
                { 9, 60000.0, 6, 15000.0, "A350-900", 300 },
                { 10, 8000.0, 7, 2900.0, "CRJ900", 90 }
            });

        migrationBuilder.InsertData(
            table: "Flights",
            columns: new[] { "Id", "ArrivalAirport", "ArrivalDateTime", "Code", "DepartureAirport", "DepartureDateTime", "FlightDuration", "ModelId" },
            values: new object[,]
            {
                { 1, "LHR", new DateTime(2025, 10, 1, 8, 0, 0, 0, DateTimeKind.Utc), "SU1001", "SVO", new DateTime(2025, 10, 1, 6, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 2, 0, 0, 0), 1 },
                { 2, "JFK", new DateTime(2025, 10, 2, 17, 0, 0, 0, DateTimeKind.Utc), "SU1002", "SVO", new DateTime(2025, 10, 2, 11, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 6, 0, 0, 0), 2 },
                { 3, "CDG", new DateTime(2025, 10, 3, 8, 0, 0, 0, DateTimeKind.Utc), "SU1003", "LED", new DateTime(2025, 10, 3, 5, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 3, 0, 0, 0), 3 },
                { 4, "DXB", new DateTime(2025, 10, 4, 16, 0, 0, 0, DateTimeKind.Utc), "SU1004", "VKO", new DateTime(2025, 10, 4, 10, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 6, 0, 0, 0), 4 },
                { 5, "SIN", new DateTime(2025, 10, 6, 2, 0, 0, 0, DateTimeKind.Utc), "SU1005", "SVO", new DateTime(2025, 10, 5, 18, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 8, 0, 0, 0), 5 },
                { 6, "HND", new DateTime(2025, 10, 6, 11, 0, 0, 0, DateTimeKind.Utc), "SU1006", "SVO", new DateTime(2025, 10, 6, 2, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 9, 0, 0, 0), 6 },
                { 7, "BER", new DateTime(2025, 10, 7, 9, 0, 0, 0, DateTimeKind.Utc), "SU1007", "LED", new DateTime(2025, 10, 7, 7, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 2, 0, 0, 0), 7 },
                { 8, "LHR", new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Utc), "SU1008", "SVO", new DateTime(2025, 10, 8, 12, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 2, 0, 0, 0), 8 },
                { 9, "CDG", new DateTime(2025, 10, 9, 7, 0, 0, 0, DateTimeKind.Utc), "SU1009", "VKO", new DateTime(2025, 10, 9, 4, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 3, 0, 0, 0), 9 },
                { 10, "JFK", new DateTime(2025, 10, 10, 9, 0, 0, 0, DateTimeKind.Utc), "SU1010", "SVO", new DateTime(2025, 10, 10, 3, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 6, 0, 0, 0), 10 }
            });

        migrationBuilder.InsertData(
            table: "Tickets",
            columns: new[] { "Id", "FlightId", "HasHandLuggage", "PassengerId", "SeatNumber", "TotalBaggageWeightKg" },
            values: new object[,]
            {
                { 1, 1, true, 1, "12A", 0.0 },
                { 2, 1, true, 2, "12B", 0.0 },
                { 3, 1, true, 3, "13C", 15.0 },
                { 4, 1, true, 4, "12C", 15.0 },
                { 5, 2, true, 5, "14A", 20.0 },
                { 6, 2, true, 6, "14B", 0.0 },
                { 7, 2, false, 7, "14C", 25.0 },
                { 8, 3, true, 8, "10A", 0.0 },
                { 9, 3, true, 9, "10B", 10.0 },
                { 10, 3, false, 10, "10C", 0.0 },
                { 11, 4, true, 11, "15A", 12.0 },
                { 12, 4, true, 12, "15B", 0.0 },
                { 13, 4, false, 13, "15C", 8.0 },
                { 14, 5, true, 14, "16A", 5.0 },
                { 15, 5, true, 15, "16B", 0.0 },
                { 16, 5, false, 16, "16C", 20.0 },
                { 17, 6, true, 17, "17A", 0.0 },
                { 18, 6, true, 18, "17B", 25.0 },
                { 19, 6, false, 19, "17C", 0.0 },
                { 20, 7, true, 20, "18A", 0.0 },
                { 21, 7, true, 21, "18B", 5.0 },
                { 22, 7, false, 22, "18C", 0.0 },
                { 23, 8, true, 23, "19A", 10.0 },
                { 24, 8, true, 24, "19B", 0.0 },
                { 25, 8, false, 25, "19C", 8.0 },
                { 26, 9, true, 26, "20A", 0.0 },
                { 27, 9, true, 27, "20B", 10.0 },
                { 28, 9, false, 28, "20C", 0.0 },
                { 29, 10, true, 29, "21A", 0.0 },
                { 30, 10, true, 30, "21B", 15.0 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 11);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 12);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 13);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 14);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 15);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 16);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 17);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 18);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 19);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 20);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 21);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 22);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 23);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 24);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 25);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 26);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 27);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 28);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 29);

        migrationBuilder.DeleteData(
            table: "Tickets",
            keyColumn: "Id",
            keyValue: 30);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Flights",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 11);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 12);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 13);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 14);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 15);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 16);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 17);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 18);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 19);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 20);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 21);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 22);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 23);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 24);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 25);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 26);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 27);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 28);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 29);

        migrationBuilder.DeleteData(
            table: "Passengers",
            keyColumn: "Id",
            keyValue: 30);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "AircraftModels",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "AircraftFamilies",
            keyColumn: "Id",
            keyValue: 7);
    }
}
