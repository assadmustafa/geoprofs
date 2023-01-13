using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoProfs.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afdeling",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Werknemer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    functie_ID = table.Column<int>(type: "int", nullable: false),
                    voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BSN = table.Column<int>(type: "int", nullable: false),
                    telefoonnummer = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wachtwoord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contract_uren = table.Column<int>(type: "int", nullable: false),
                    uurloon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Werknemer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    afdeling_ID = table.Column<int>(type: "int", nullable: false),
                    naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfdelingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Functie_Afdeling_AfdelingID",
                        column: x => x.AfdelingID,
                        principalTable: "Afdeling",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Verlofaanvraag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    werknemer_ID = table.Column<int>(type: "int", nullable: false),
                    begin_datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eind_datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WerkenemerID = table.Column<int>(type: "int", nullable: true),
                    verlof_reden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verlofaanvraag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Verlofaanvraag_Werknemer_WerkenemerID",
                        column: x => x.WerkenemerID,
                        principalTable: "Werknemer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rapport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    werknemer_ID = table.Column<int>(type: "int", nullable: false),
                    functie_ID = table.Column<int>(type: "int", nullable: false),
                    verlofaanvraag_ID = table.Column<int>(type: "int", nullable: false),
                    weeknummer = table.Column<int>(type: "int", nullable: false),
                    aanwezige_dagen = table.Column<double>(type: "float", nullable: false),
                    afwezige_dagen = table.Column<double>(type: "float", nullable: false),
                    WerknemerID = table.Column<int>(type: "int", nullable: true),
                    FunctieID = table.Column<int>(type: "int", nullable: true),
                    VerlofaanvraagID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rapport_Functie_FunctieID",
                        column: x => x.FunctieID,
                        principalTable: "Functie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rapport_Verlofaanvraag_VerlofaanvraagID",
                        column: x => x.VerlofaanvraagID,
                        principalTable: "Verlofaanvraag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rapport_Werknemer_WerknemerID",
                        column: x => x.WerknemerID,
                        principalTable: "Werknemer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Functie_AfdelingID",
                table: "Functie",
                column: "AfdelingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rapport_FunctieID",
                table: "Rapport",
                column: "FunctieID");

            migrationBuilder.CreateIndex(
                name: "IX_Rapport_VerlofaanvraagID",
                table: "Rapport",
                column: "VerlofaanvraagID");

            migrationBuilder.CreateIndex(
                name: "IX_Rapport_WerknemerID",
                table: "Rapport",
                column: "WerknemerID");

            migrationBuilder.CreateIndex(
                name: "IX_Verlofaanvraag_WerkenemerID",
                table: "Verlofaanvraag",
                column: "WerkenemerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapport");

            migrationBuilder.DropTable(
                name: "Functie");

            migrationBuilder.DropTable(
                name: "Verlofaanvraag");

            migrationBuilder.DropTable(
                name: "Afdeling");

            migrationBuilder.DropTable(
                name: "Werknemer");
        }
    }
}
