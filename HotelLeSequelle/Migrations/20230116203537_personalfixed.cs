using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLeSequelle.Migrations
{
    public partial class personalfixed : Migration
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
                    Kortuppgifter = table.Column<int>(type: "int", nullable: false),
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
                    Roll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Pris = table.Column<int>(type: "int", nullable: false)
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
                    RummetsVåningId = table.Column<int>(type: "int", nullable: false),
                    VåningsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rum_Våningar_RummetsVåningId",
                        column: x => x.RummetsVåningId,
                        principalTable: "Våningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bokningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotellId = table.Column<int>(type: "int", nullable: true),
                    KundId = table.Column<int>(type: "int", nullable: true),
                    BokatRumId = table.Column<int>(type: "int", nullable: true),
                    BokandePersonalId = table.Column<int>(type: "int", nullable: true),
                    IncheckningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcheckningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceptionistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bokningar_Hotell_HotellId",
                        column: x => x.HotellId,
                        principalTable: "Hotell",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bokningar_Kunder_KundId",
                        column: x => x.KundId,
                        principalTable: "Kunder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bokningar_Personal_BokandePersonalId",
                        column: x => x.BokandePersonalId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bokningar_Personal_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bokningar_Rum_BokatRumId",
                        column: x => x.BokatRumId,
                        principalTable: "Rum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tilläggsbeställningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SäljareId = table.Column<int>(type: "int", nullable: false),
                    SäljarId = table.Column<int>(type: "int", nullable: false),
                    BokningId = table.Column<int>(type: "int", nullable: false),
                    BokningsId = table.Column<int>(type: "int", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    ReceptionistId = table.Column<int>(type: "int", nullable: true),
                    ServitörId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilläggsbeställningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Bokningar_BokningId",
                        column: x => x.BokningId,
                        principalTable: "Bokningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Personal_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tilläggsbeställningar_Personal_SäljareId",
                        column: x => x.SäljareId,
                        principalTable: "Personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TilläggsbeställningarId = table.Column<int>(type: "int", nullable: false),
                    TilläggsvarorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilläggsbeställningTilläggsvara", x => new { x.TilläggsbeställningarId, x.TilläggsvarorId });
                    table.ForeignKey(
                        name: "FK_TilläggsbeställningTilläggsvara_Tilläggsbeställningar_TilläggsbeställningarId",
                        column: x => x.TilläggsbeställningarId,
                        principalTable: "Tilläggsbeställningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TilläggsbeställningTilläggsvara_Tilläggsvaror_TilläggsvarorId",
                        column: x => x.TilläggsvarorId,
                        principalTable: "Tilläggsvaror",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_BokandePersonalId",
                table: "Bokningar",
                column: "BokandePersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_BokatRumId",
                table: "Bokningar",
                column: "BokatRumId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_HotellId",
                table: "Bokningar",
                column: "HotellId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_KundId",
                table: "Bokningar",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_ReceptionistId",
                table: "Bokningar",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Rum_RummetsVåningId",
                table: "Rum",
                column: "RummetsVåningId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_BokningId",
                table: "Tilläggsbeställningar",
                column: "BokningId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_ReceptionistId",
                table: "Tilläggsbeställningar",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_SäljareId",
                table: "Tilläggsbeställningar",
                column: "SäljareId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilläggsbeställningar_ServitörId",
                table: "Tilläggsbeställningar",
                column: "ServitörId");

            migrationBuilder.CreateIndex(
                name: "IX_TilläggsbeställningTilläggsvara_TilläggsvarorId",
                table: "TilläggsbeställningTilläggsvara",
                column: "TilläggsvarorId");

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
