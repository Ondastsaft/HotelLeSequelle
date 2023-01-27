using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_ReceptionistPersonId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReceptionistPersonId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReceptionistPersonId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReceptionistID",
                table: "Person",
                newName: "ReceptionistId");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_ReservationId",
                table: "Reservations",
                column: "ReservationId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Person_ReservationId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReceptionistId",
                table: "Person",
                newName: "ReceptionistID");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReceptionistPersonId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReceptionistPersonId",
                table: "Reservations",
                column: "ReceptionistPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Person_ReceptionistPersonId",
                table: "Reservations",
                column: "ReceptionistPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
