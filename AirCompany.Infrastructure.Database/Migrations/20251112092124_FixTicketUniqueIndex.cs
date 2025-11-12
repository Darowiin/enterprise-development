using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirCompany.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class FixTicketUniqueIndex : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_tickets_flight_id",
            table: "tickets");

        migrationBuilder.DropIndex(
            name: "IX_tickets_seat_number",
            table: "tickets");

        migrationBuilder.CreateIndex(
            name: "IX_tickets_flight_id_seat_number",
            table: "tickets",
            columns: ["flight_id", "seat_number"],
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_tickets_flight_id_seat_number",
            table: "tickets");

        migrationBuilder.CreateIndex(
            name: "IX_tickets_flight_id",
            table: "tickets",
            column: "flight_id");

        migrationBuilder.CreateIndex(
            name: "IX_tickets_seat_number",
            table: "tickets",
            column: "seat_number",
            unique: true);
    }
}
