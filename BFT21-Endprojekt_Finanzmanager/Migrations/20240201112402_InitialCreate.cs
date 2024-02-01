using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BFT21_Endprojekt_Finanzmanager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vorname = table.Column<string>(type: "TEXT", nullable: false),
                    nachname = table.Column<string>(type: "TEXT", nullable: false),
                    login = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Konten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    inhaberId = table.Column<int>(type: "INTEGER", nullable: false),
                    anzeigeName = table.Column<string>(type: "TEXT", nullable: false),
                    kontoname = table.Column<string>(type: "TEXT", nullable: false),
                    kontoTyp = table.Column<int>(type: "INTEGER", nullable: false),
                    waerungsTyp = table.Column<string>(type: "TEXT", nullable: false),
                    kontostand = table.Column<double>(type: "REAL", nullable: false),
                    lagerort = table.Column<string>(type: "TEXT", nullable: false),
                    bank = table.Column<string>(type: "TEXT", nullable: false),
                    laendercode = table.Column<string>(type: "TEXT", nullable: false),
                    pruefsumme = table.Column<int>(type: "INTEGER", nullable: false),
                    bankleitzahl = table.Column<int>(type: "INTEGER", nullable: false),
                    kontonummer = table.Column<int>(type: "INTEGER", nullable: false),
                    webAdresse = table.Column<string>(type: "TEXT", nullable: false),
                    walletAdress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konten_Personen_inhaberId",
                        column: x => x.inhaberId,
                        principalTable: "Personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kapitalUnterteilungsGruppen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    betrag = table.Column<double>(type: "REAL", nullable: false),
                    einct = table.Column<int>(type: "INTEGER", nullable: false),
                    zweict = table.Column<int>(type: "INTEGER", nullable: false),
                    fuenfct = table.Column<int>(type: "INTEGER", nullable: false),
                    zehnct = table.Column<int>(type: "INTEGER", nullable: false),
                    zwanzigct = table.Column<int>(type: "INTEGER", nullable: false),
                    fuenfzigct = table.Column<int>(type: "INTEGER", nullable: false),
                    eineuro = table.Column<int>(type: "INTEGER", nullable: false),
                    zweieuro = table.Column<int>(type: "INTEGER", nullable: false),
                    fuenfeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    zehneuro = table.Column<int>(type: "INTEGER", nullable: false),
                    zwanzigeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    fuenfzigeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    einhuderteuro = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kapitalUnterteilungsGruppen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kapitalUnterteilungsGruppen_Konten_kontoId",
                        column: x => x.kontoId,
                        principalTable: "Konten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kapitalUnterteilungsGruppen_kontoId",
                table: "kapitalUnterteilungsGruppen",
                column: "kontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Konten_inhaberId",
                table: "Konten",
                column: "inhaberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kapitalUnterteilungsGruppen");

            migrationBuilder.DropTable(
                name: "Konten");

            migrationBuilder.DropTable(
                name: "Personen");
        }
    }
}
