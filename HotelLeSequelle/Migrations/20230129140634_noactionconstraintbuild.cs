using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class noactionconstraintbuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations",
                column: "ReservationReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations",
                column: "ReservationReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
