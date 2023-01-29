using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations",
                column: "ReservationCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations",
                column: "ReservationReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations",
                column: "ReservationCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Receptionists_ReservationReceptionistId",
                table: "Reservations",
                column: "ReservationReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId");
        }
    }
}
