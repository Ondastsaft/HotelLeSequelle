using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class majorchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Hotell_HotellId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Kunder_KundId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Personal_BokandePersonalId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Rum_BokatRumId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Tilläggsbeställningar_Personal_SäljareId",
                table: "Tilläggsbeställningar");

            migrationBuilder.DropColumn(
                name: "SäljarId",
                table: "Tilläggsbeställningar");

            migrationBuilder.DropColumn(
                name: "Roll",
                table: "Personal");

            migrationBuilder.RenameColumn(
                name: "SäljareId",
                table: "Tilläggsbeställningar",
                newName: "PersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_Tilläggsbeställningar_SäljareId",
                table: "Tilläggsbeställningar",
                newName: "IX_Tilläggsbeställningar_PersonalId");

            migrationBuilder.AddColumn<int>(
                name: "TilläggsbeställningsId",
                table: "Personal",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kortuppgifter",
                table: "Kunder",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Bokningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotellId",
                table: "Bokningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BokatRumId",
                table: "Bokningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BokandePersonalId",
                table: "Bokningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Hotell_HotellId",
                table: "Bokningar",
                column: "HotellId",
                principalTable: "Hotell",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Kunder_KundId",
                table: "Bokningar",
                column: "KundId",
                principalTable: "Kunder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Personal_BokandePersonalId",
                table: "Bokningar",
                column: "BokandePersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Rum_BokatRumId",
                table: "Bokningar",
                column: "BokatRumId",
                principalTable: "Rum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tilläggsbeställningar_Personal_PersonalId",
                table: "Tilläggsbeställningar",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Hotell_HotellId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Kunder_KundId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Personal_BokandePersonalId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Rum_BokatRumId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Tilläggsbeställningar_Personal_PersonalId",
                table: "Tilläggsbeställningar");

            migrationBuilder.DropColumn(
                name: "TilläggsbeställningsId",
                table: "Personal");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "Tilläggsbeställningar",
                newName: "SäljareId");

            migrationBuilder.RenameIndex(
                name: "IX_Tilläggsbeställningar_PersonalId",
                table: "Tilläggsbeställningar",
                newName: "IX_Tilläggsbeställningar_SäljareId");

            migrationBuilder.AddColumn<int>(
                name: "SäljarId",
                table: "Tilläggsbeställningar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Roll",
                table: "Personal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kortuppgifter",
                table: "Kunder",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Bokningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotellId",
                table: "Bokningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BokatRumId",
                table: "Bokningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BokandePersonalId",
                table: "Bokningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Hotell_HotellId",
                table: "Bokningar",
                column: "HotellId",
                principalTable: "Hotell",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Kunder_KundId",
                table: "Bokningar",
                column: "KundId",
                principalTable: "Kunder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Personal_BokandePersonalId",
                table: "Bokningar",
                column: "BokandePersonalId",
                principalTable: "Personal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Rum_BokatRumId",
                table: "Bokningar",
                column: "BokatRumId",
                principalTable: "Rum",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tilläggsbeställningar_Personal_SäljareId",
                table: "Tilläggsbeställningar",
                column: "SäljareId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
