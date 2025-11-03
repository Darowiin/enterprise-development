using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirCompany.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class RenameToSnakeCase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_AircraftModels_AircraftFamilies_FamilyId",
            table: "AircraftModels");

        migrationBuilder.DropForeignKey(
            name: "FK_Flights_AircraftModels_ModelId",
            table: "Flights");

        migrationBuilder.DropForeignKey(
            name: "FK_Tickets_Flights_FlightId",
            table: "Tickets");

        migrationBuilder.DropForeignKey(
            name: "FK_Tickets_Passengers_PassengerId",
            table: "Tickets");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Tickets",
            table: "Tickets");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Passengers",
            table: "Passengers");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Flights",
            table: "Flights");

        migrationBuilder.DropPrimaryKey(
            name: "PK_AircraftModels",
            table: "AircraftModels");

        migrationBuilder.DropPrimaryKey(
            name: "PK_AircraftFamilies",
            table: "AircraftFamilies");

        migrationBuilder.RenameTable(
            name: "Tickets",
            newName: "tickets");

        migrationBuilder.RenameTable(
            name: "Passengers",
            newName: "passengers");

        migrationBuilder.RenameTable(
            name: "Flights",
            newName: "flights");

        migrationBuilder.RenameTable(
            name: "AircraftModels",
            newName: "aircraft_models");

        migrationBuilder.RenameTable(
            name: "AircraftFamilies",
            newName: "aircraft_families");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "tickets",
            newName: "id");

        migrationBuilder.RenameColumn(
            name: "TotalBaggageWeightKg",
            table: "tickets",
            newName: "total_baggage_weight");

        migrationBuilder.RenameColumn(
            name: "SeatNumber",
            table: "tickets",
            newName: "seat_number");

        migrationBuilder.RenameColumn(
            name: "PassengerId",
            table: "tickets",
            newName: "passenger_id");

        migrationBuilder.RenameColumn(
            name: "HasHandLuggage",
            table: "tickets",
            newName: "has_hand_luggage");

        migrationBuilder.RenameColumn(
            name: "FlightId",
            table: "tickets",
            newName: "flight_id");

        migrationBuilder.RenameIndex(
            name: "IX_Tickets_SeatNumber",
            table: "tickets",
            newName: "IX_tickets_seat_number");

        migrationBuilder.RenameIndex(
            name: "IX_Tickets_PassengerId",
            table: "tickets",
            newName: "IX_tickets_passenger_id");

        migrationBuilder.RenameIndex(
            name: "IX_Tickets_FlightId",
            table: "tickets",
            newName: "IX_tickets_flight_id");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "passengers",
            newName: "id");

        migrationBuilder.RenameColumn(
            name: "PassportNumber",
            table: "passengers",
            newName: "passport_number");

        migrationBuilder.RenameColumn(
            name: "FullName",
            table: "passengers",
            newName: "full_name");

        migrationBuilder.RenameColumn(
            name: "BirthDate",
            table: "passengers",
            newName: "birth_date");

        migrationBuilder.RenameColumn(
            name: "Code",
            table: "flights",
            newName: "code");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "flights",
            newName: "id");

        migrationBuilder.RenameColumn(
            name: "ModelId",
            table: "flights",
            newName: "model_id");

        migrationBuilder.RenameColumn(
            name: "FlightDuration",
            table: "flights",
            newName: "flight_duration");

        migrationBuilder.RenameColumn(
            name: "DepartureDateTime",
            table: "flights",
            newName: "departure_datetime");

        migrationBuilder.RenameColumn(
            name: "DepartureAirport",
            table: "flights",
            newName: "departure_airport");

        migrationBuilder.RenameColumn(
            name: "ArrivalDateTime",
            table: "flights",
            newName: "arrival_datetime");

        migrationBuilder.RenameColumn(
            name: "ArrivalAirport",
            table: "flights",
            newName: "arrival_airport");

        migrationBuilder.RenameIndex(
            name: "IX_Flights_Code",
            table: "flights",
            newName: "IX_flights_code");

        migrationBuilder.RenameIndex(
            name: "IX_Flights_ModelId",
            table: "flights",
            newName: "IX_flights_model_id");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "aircraft_models",
            newName: "id");

        migrationBuilder.RenameColumn(
            name: "PassengerCapacity",
            table: "aircraft_models",
            newName: "passenger_capacity");

        migrationBuilder.RenameColumn(
            name: "ModelName",
            table: "aircraft_models",
            newName: "model_name");

        migrationBuilder.RenameColumn(
            name: "FlightRangeKm",
            table: "aircraft_models",
            newName: "flight_range");

        migrationBuilder.RenameColumn(
            name: "FamilyId",
            table: "aircraft_models",
            newName: "family_id");

        migrationBuilder.RenameColumn(
            name: "CargoCapacityKg",
            table: "aircraft_models",
            newName: "cargo_capacity");

        migrationBuilder.RenameIndex(
            name: "IX_AircraftModels_FamilyId",
            table: "aircraft_models",
            newName: "IX_aircraft_models_family_id");

        migrationBuilder.RenameColumn(
            name: "Name",
            table: "aircraft_families",
            newName: "name");

        migrationBuilder.RenameColumn(
            name: "Manufacturer",
            table: "aircraft_families",
            newName: "manufacturer");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "aircraft_families",
            newName: "id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_tickets",
            table: "tickets",
            column: "id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_passengers",
            table: "passengers",
            column: "id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_flights",
            table: "flights",
            column: "id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_aircraft_models",
            table: "aircraft_models",
            column: "id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_aircraft_families",
            table: "aircraft_families",
            column: "id");

        migrationBuilder.AddForeignKey(
            name: "FK_aircraft_models_aircraft_families_family_id",
            table: "aircraft_models",
            column: "family_id",
            principalTable: "aircraft_families",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_flights_aircraft_models_model_id",
            table: "flights",
            column: "model_id",
            principalTable: "aircraft_models",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_tickets_flights_flight_id",
            table: "tickets",
            column: "flight_id",
            principalTable: "flights",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_tickets_passengers_passenger_id",
            table: "tickets",
            column: "passenger_id",
            principalTable: "passengers",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_aircraft_models_aircraft_families_family_id",
            table: "aircraft_models");

        migrationBuilder.DropForeignKey(
            name: "FK_flights_aircraft_models_model_id",
            table: "flights");

        migrationBuilder.DropForeignKey(
            name: "FK_tickets_flights_flight_id",
            table: "tickets");

        migrationBuilder.DropForeignKey(
            name: "FK_tickets_passengers_passenger_id",
            table: "tickets");

        migrationBuilder.DropPrimaryKey(
            name: "PK_tickets",
            table: "tickets");

        migrationBuilder.DropPrimaryKey(
            name: "PK_passengers",
            table: "passengers");

        migrationBuilder.DropPrimaryKey(
            name: "PK_flights",
            table: "flights");

        migrationBuilder.DropPrimaryKey(
            name: "PK_aircraft_models",
            table: "aircraft_models");

        migrationBuilder.DropPrimaryKey(
            name: "PK_aircraft_families",
            table: "aircraft_families");

        migrationBuilder.RenameTable(
            name: "tickets",
            newName: "Tickets");

        migrationBuilder.RenameTable(
            name: "passengers",
            newName: "Passengers");

        migrationBuilder.RenameTable(
            name: "flights",
            newName: "Flights");

        migrationBuilder.RenameTable(
            name: "aircraft_models",
            newName: "AircraftModels");

        migrationBuilder.RenameTable(
            name: "aircraft_families",
            newName: "AircraftFamilies");

        migrationBuilder.RenameColumn(
            name: "id",
            table: "Tickets",
            newName: "Id");

        migrationBuilder.RenameColumn(
            name: "total_baggage_weight",
            table: "Tickets",
            newName: "TotalBaggageWeightKg");

        migrationBuilder.RenameColumn(
            name: "seat_number",
            table: "Tickets",
            newName: "SeatNumber");

        migrationBuilder.RenameColumn(
            name: "passenger_id",
            table: "Tickets",
            newName: "PassengerId");

        migrationBuilder.RenameColumn(
            name: "has_hand_luggage",
            table: "Tickets",
            newName: "HasHandLuggage");

        migrationBuilder.RenameColumn(
            name: "flight_id",
            table: "Tickets",
            newName: "FlightId");

        migrationBuilder.RenameIndex(
            name: "IX_tickets_seat_number",
            table: "Tickets",
            newName: "IX_Tickets_SeatNumber");

        migrationBuilder.RenameIndex(
            name: "IX_tickets_passenger_id",
            table: "Tickets",
            newName: "IX_Tickets_PassengerId");

        migrationBuilder.RenameIndex(
            name: "IX_tickets_flight_id",
            table: "Tickets",
            newName: "IX_Tickets_FlightId");

        migrationBuilder.RenameColumn(
            name: "id",
            table: "Passengers",
            newName: "Id");

        migrationBuilder.RenameColumn(
            name: "passport_number",
            table: "Passengers",
            newName: "PassportNumber");

        migrationBuilder.RenameColumn(
            name: "full_name",
            table: "Passengers",
            newName: "FullName");

        migrationBuilder.RenameColumn(
            name: "birth_date",
            table: "Passengers",
            newName: "BirthDate");

        migrationBuilder.RenameColumn(
            name: "code",
            table: "Flights",
            newName: "Code");

        migrationBuilder.RenameColumn(
            name: "id",
            table: "Flights",
            newName: "Id");

        migrationBuilder.RenameColumn(
            name: "model_id",
            table: "Flights",
            newName: "ModelId");

        migrationBuilder.RenameColumn(
            name: "flight_duration",
            table: "Flights",
            newName: "FlightDuration");

        migrationBuilder.RenameColumn(
            name: "departure_datetime",
            table: "Flights",
            newName: "DepartureDateTime");

        migrationBuilder.RenameColumn(
            name: "departure_airport",
            table: "Flights",
            newName: "DepartureAirport");

        migrationBuilder.RenameColumn(
            name: "arrival_datetime",
            table: "Flights",
            newName: "ArrivalDateTime");

        migrationBuilder.RenameColumn(
            name: "arrival_airport",
            table: "Flights",
            newName: "ArrivalAirport");

        migrationBuilder.RenameIndex(
            name: "IX_flights_code",
            table: "Flights",
            newName: "IX_Flights_Code");

        migrationBuilder.RenameIndex(
            name: "IX_flights_model_id",
            table: "Flights",
            newName: "IX_Flights_ModelId");

        migrationBuilder.RenameColumn(
            name: "id",
            table: "AircraftModels",
            newName: "Id");

        migrationBuilder.RenameColumn(
            name: "passenger_capacity",
            table: "AircraftModels",
            newName: "PassengerCapacity");

        migrationBuilder.RenameColumn(
            name: "model_name",
            table: "AircraftModels",
            newName: "ModelName");

        migrationBuilder.RenameColumn(
            name: "flight_range",
            table: "AircraftModels",
            newName: "FlightRangeKm");

        migrationBuilder.RenameColumn(
            name: "family_id",
            table: "AircraftModels",
            newName: "FamilyId");

        migrationBuilder.RenameColumn(
            name: "cargo_capacity",
            table: "AircraftModels",
            newName: "CargoCapacityKg");

        migrationBuilder.RenameIndex(
            name: "IX_aircraft_models_family_id",
            table: "AircraftModels",
            newName: "IX_AircraftModels_FamilyId");

        migrationBuilder.RenameColumn(
            name: "name",
            table: "AircraftFamilies",
            newName: "Name");

        migrationBuilder.RenameColumn(
            name: "manufacturer",
            table: "AircraftFamilies",
            newName: "Manufacturer");

        migrationBuilder.RenameColumn(
            name: "id",
            table: "AircraftFamilies",
            newName: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Tickets",
            table: "Tickets",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Passengers",
            table: "Passengers",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Flights",
            table: "Flights",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_AircraftModels",
            table: "AircraftModels",
            column: "Id");

        migrationBuilder.AddPrimaryKey(
            name: "PK_AircraftFamilies",
            table: "AircraftFamilies",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_AircraftModels_AircraftFamilies_FamilyId",
            table: "AircraftModels",
            column: "FamilyId",
            principalTable: "AircraftFamilies",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Flights_AircraftModels_ModelId",
            table: "Flights",
            column: "ModelId",
            principalTable: "AircraftModels",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Tickets_Flights_FlightId",
            table: "Tickets",
            column: "FlightId",
            principalTable: "Flights",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Tickets_Passengers_PassengerId",
            table: "Tickets",
            column: "PassengerId",
            principalTable: "Passengers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
