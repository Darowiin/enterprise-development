using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirCompany.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AircraftFamilies",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Manufacturer = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftFamilies", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Passengers",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                PassportNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Passengers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AircraftModels",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                ModelName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                FamilyId = table.Column<int>(type: "integer", nullable: false),
                FlightRangeKm = table.Column<double>(type: "double precision", nullable: false),
                PassengerCapacity = table.Column<int>(type: "integer", nullable: false),
                CargoCapacityKg = table.Column<double>(type: "double precision", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AircraftModels", x => x.Id);
                table.ForeignKey(
                    name: "FK_AircraftModels_AircraftFamilies_FamilyId",
                    column: x => x.FamilyId,
                    principalTable: "AircraftFamilies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Flights",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Code = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                DepartureAirport = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                ArrivalAirport = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                DepartureDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ArrivalDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                FlightDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                ModelId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Flights", x => x.Id);
                table.ForeignKey(
                    name: "FK_Flights_AircraftModels_ModelId",
                    column: x => x.ModelId,
                    principalTable: "AircraftModels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tickets",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                FlightId = table.Column<int>(type: "integer", nullable: false),
                PassengerId = table.Column<int>(type: "integer", nullable: false),
                SeatNumber = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                HasHandLuggage = table.Column<bool>(type: "boolean", nullable: true),
                TotalBaggageWeightKg = table.Column<double>(type: "double precision", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tickets", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tickets_Flights_FlightId",
                    column: x => x.FlightId,
                    principalTable: "Flights",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Tickets_Passengers_PassengerId",
                    column: x => x.PassengerId,
                    principalTable: "Passengers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AircraftModels_FamilyId",
            table: "AircraftModels",
            column: "FamilyId");

        migrationBuilder.CreateIndex(
            name: "IX_Flights_Code",
            table: "Flights",
            column: "Code",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Flights_ModelId",
            table: "Flights",
            column: "ModelId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_FlightId",
            table: "Tickets",
            column: "FlightId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_PassengerId",
            table: "Tickets",
            column: "PassengerId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_SeatNumber",
            table: "Tickets",
            column: "SeatNumber",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tickets");

        migrationBuilder.DropTable(
            name: "Flights");

        migrationBuilder.DropTable(
            name: "Passengers");

        migrationBuilder.DropTable(
            name: "AircraftModels");

        migrationBuilder.DropTable(
            name: "AircraftFamilies");
    }
}
