using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class removedreservationfromsideorderproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SideOrderProduct_Reservations_ReservationId",
                table: "SideOrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_SideOrderProduct_ReservationId",
                table: "SideOrderProduct");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "SideOrderProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "SideOrderProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SideOrderProduct_ReservationId",
                table: "SideOrderProduct",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SideOrderProduct_Reservations_ReservationId",
                table: "SideOrderProduct",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
