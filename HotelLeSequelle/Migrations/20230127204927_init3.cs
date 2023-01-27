using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_CustomerId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_CustomerId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
