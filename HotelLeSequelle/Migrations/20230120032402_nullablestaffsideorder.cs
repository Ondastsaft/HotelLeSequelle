using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class nullablestaffsideorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Products_ProductId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SideOrders_Staff_StaffId",
                table: "SideOrders");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ProductId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "SideOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SideOrders_Staff_StaffId",
                table: "SideOrders",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SideOrders_Staff_StaffId",
                table: "SideOrders");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "SideOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ProductId",
                table: "Reservations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Products_ProductId",
                table: "Reservations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SideOrders_Staff_StaffId",
                table: "SideOrders",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
