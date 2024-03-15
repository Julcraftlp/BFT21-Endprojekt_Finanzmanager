using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BFT21_Endprojekt_Finanzmanager.Migrations
{
    public partial class MainSysMigri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankLeitZahl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Bank = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLeitZahl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laendercodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kürzel = table.Column<string>(type: "TEXT", nullable: false),
                    Land = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laendercodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionsTypen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Absetzbar = table.Column<bool>(type: "INTEGER", nullable: false),
                    Steuersatz = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionsTypen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Konten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Betrag = table.Column<double>(type: "REAL", nullable: false),
                    KontoTyp = table.Column<bool>(type: "INTEGER", nullable: false),
                    TF1 = table.Column<string>(type: "TEXT", nullable: false),
                    LaendercodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Kontrollsumme = table.Column<int>(type: "INTEGER", nullable: false),
                    BankLeitZahlId = table.Column<int>(type: "INTEGER", nullable: false),
                    KontoNummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Gültigkeit = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konten_BankLeitZahl_BankLeitZahlId",
                        column: x => x.BankLeitZahlId,
                        principalTable: "BankLeitZahl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konten_Laendercodes_LaendercodeId",
                        column: x => x.LaendercodeId,
                        principalTable: "Laendercodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konten_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buchungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuchungsTyp = table.Column<short>(type: "INTEGER", nullable: false),
                    NettoSum = table.Column<double>(type: "REAL", nullable: false),
                    BruttoSum = table.Column<double>(type: "REAL", nullable: false),
                    EigKontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExtKontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buchungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buchungen_Konten_EigKontoId",
                        column: x => x.EigKontoId,
                        principalTable: "Konten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buchungen_Konten_ExtKontoId",
                        column: x => x.ExtKontoId,
                        principalTable: "Konten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buchungen_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuchungsPositionen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuchungId = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionsTypId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    BPPU = table.Column<double>(type: "REAL", nullable: false),
                    Amt = table.Column<int>(type: "INTEGER", nullable: false),
                    NettoPreis = table.Column<double>(type: "REAL", nullable: false),
                    BruttoPreis = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuchungsPositionen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuchungsPositionen_Buchungen_BuchungId",
                        column: x => x.BuchungId,
                        principalTable: "Buchungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuchungsPositionen_PositionsTypen_PositionsTypId",
                        column: x => x.PositionsTypId,
                        principalTable: "PositionsTypen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_EigKontoId",
                table: "Buchungen",
                column: "EigKontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_ExtKontoId",
                table: "Buchungen",
                column: "ExtKontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_UserId",
                table: "Buchungen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuchungsPositionen_BuchungId",
                table: "BuchungsPositionen",
                column: "BuchungId");

            migrationBuilder.CreateIndex(
                name: "IX_BuchungsPositionen_PositionsTypId",
                table: "BuchungsPositionen",
                column: "PositionsTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Konten_BankLeitZahlId",
                table: "Konten",
                column: "BankLeitZahlId");

            migrationBuilder.CreateIndex(
                name: "IX_Konten_LaendercodeId",
                table: "Konten",
                column: "LaendercodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Konten_UserId",
                table: "Konten",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuchungsPositionen");

            migrationBuilder.DropTable(
                name: "Buchungen");

            migrationBuilder.DropTable(
                name: "PositionsTypen");

            migrationBuilder.DropTable(
                name: "Konten");

            migrationBuilder.DropTable(
                name: "BankLeitZahl");

            migrationBuilder.DropTable(
                name: "Laendercodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
