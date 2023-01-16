using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class Fixesinboknings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotell",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntalRum = table.Column<int>(type: "int", nullable: false),
                    AntalVåningar = table.Column<int>(type: "int", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GatuAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hemsida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotell", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kortuppgifter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalitet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatuadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anställningsdatum = table.Column<int>(type: "int", nullable: false),
                    Anställningsnummer = table.Column<int>(type: "int", nullable: false),
                    Lösenord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TilläggsbeställningsId = table.Column<int>(type: "int", nullable: true),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalitet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatuadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tilläggsvaror",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilläggsvaror", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Våningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Våningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Våningar_Hotell_HotellId",
                        column: x => x.HotellId,
                        principalTable: "Hotell",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VåningsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rum_Våningar_VåningsId",
                        column: x => x.VåningsId,
                        principalTable: "Våningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bokningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundId = table.Column<int>(type: "int", nullable: false),
                    RumId = table.Column<int>(type: "int", nullable: false),
                    ReceptionistId = table.Column<int>(type: "int", nullable: false),
                    IncheckningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcheckningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bokningar_Kunder_KundId",
                        column: x => x.KundId,
                        principalTable: "Kunder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bokningar_Personal_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bokningar_Rum_RumId",
                        column: x => x.RumId,
                        principalTable: "Rum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tilläggsbeställningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    BokningsId = table.Column<int>(type: "int", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    ServitörId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilläggsbeställningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Bokningar_BokningsId",
                        column: x => x.BokningsId,
                        principalTable: "Bokningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Personal_ServitörId",
                        column: x => x.ServitörId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TilläggsbeställningTilläggsvara",
                columns: table => new
                {
                    TilläggsbeställningId = table.Column<int>(type: "int", nullable: false),
                    TilläggsvaraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilläggsbeställningTilläggsvara", x => new { x.TilläggsbeställningId, x.TilläggsvaraId });
                    table.ForeignKey(
                        name: "FK_TilläggsbeställningTilläggsvara_Tilläggsbeställningar_TilläggsbeställningId",
                        column: x => x.TilläggsbeställningId,
                        principalTable: "Tilläggsbeställningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TilläggsbeställningTilläggsvara_Tilläggsvaror_TilläggsvaraId",
                        column: x => x.TilläggsvaraId,
                        principalTable: "Tilläggsvaror",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_KundId",
                table: "Bokningar",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_ReceptionistId",
                table: "Bokningar",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_RumId",
                table: "Bokningar",
                column: "RumId");

            migrationBuilder.CreateIndex(
                name: "IX_Rum_VåningsId",
                table: "Rum",
                column: "VåningsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_BokningsId",
                table: "Tilläggsbeställningar",
                column: "BokningsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_PersonalId",
                table: "Tilläggsbeställningar",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_ServitörId",
                table: "Tilläggsbeställningar",
                column: "ServitörId");

            migrationBuilder.CreateIndex(
                name: "IX_TilläggsbeställningTilläggsvara_TilläggsvaraId",
                table: "TilläggsbeställningTilläggsvara",
                column: "TilläggsvaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Våningar_HotellId",
                table: "Våningar",
                column: "HotellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TilläggsbeställningTilläggsvara");

            migrationBuilder.DropTable(
                name: "Tilläggsbeställningar");

            migrationBuilder.DropTable(
                name: "Tilläggsvaror");

            migrationBuilder.DropTable(
                name: "Bokningar");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Rum");

            migrationBuilder.DropTable(
                name: "Våningar");

            migrationBuilder.DropTable(
                name: "Hotell");
        }
    }
}
