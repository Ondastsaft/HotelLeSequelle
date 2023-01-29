using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class reversedconstaintbuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations",
                column: "ReservationCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_ReservationCustomerID",
                table: "Reservations",
                column: "ReservationCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
