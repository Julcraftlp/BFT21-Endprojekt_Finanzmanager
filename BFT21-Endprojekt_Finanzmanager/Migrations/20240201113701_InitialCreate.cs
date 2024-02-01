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
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
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
                    InhaberId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnzeigeName = table.Column<string>(type: "TEXT", nullable: false),
                    Kontoname = table.Column<string>(type: "TEXT", nullable: false),
                    KontoTyp = table.Column<int>(type: "INTEGER", nullable: false),
                    WaerungsTyp = table.Column<string>(type: "TEXT", nullable: false),
                    Kontostand = table.Column<double>(type: "REAL", nullable: false),
                    Bank = table.Column<string>(type: "TEXT", nullable: false),
                    Laendercode = table.Column<string>(type: "TEXT", nullable: false),
                    Pruefsumme = table.Column<int>(type: "INTEGER", nullable: false),
                    Bankleitzahl = table.Column<int>(type: "INTEGER", nullable: false),
                    Kontonummer = table.Column<int>(type: "INTEGER", nullable: false),
                    WebAdresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konten_Personen_InhaberId",
                        column: x => x.InhaberId,
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
                    KontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Betrag = table.Column<double>(type: "REAL", nullable: false),
                    Einct = table.Column<int>(type: "INTEGER", nullable: false),
                    Zweict = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuenfct = table.Column<int>(type: "INTEGER", nullable: false),
                    Zehnct = table.Column<int>(type: "INTEGER", nullable: false),
                    Zwanzigct = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuenfzigct = table.Column<int>(type: "INTEGER", nullable: false),
                    Eineuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Zweieuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuenfeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Zehneuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Zwanzigeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuenfzigeuro = table.Column<int>(type: "INTEGER", nullable: false),
                    Einhuderteuro = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kapitalUnterteilungsGruppen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kapitalUnterteilungsGruppen_Konten_KontoId",
                        column: x => x.KontoId,
                        principalTable: "Konten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kapitalUnterteilungsGruppen_KontoId",
                table: "kapitalUnterteilungsGruppen",
                column: "KontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Konten_InhaberId",
                table: "Konten",
                column: "InhaberId");
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
