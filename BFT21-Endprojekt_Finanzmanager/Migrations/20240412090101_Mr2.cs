using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BFT21_Endprojekt_Finanzmanager.Migrations
{
    public partial class Mr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Konten_ExtKontoId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_BuchungsPositionen_PositionsTypen_PositionsTypId",
                table: "BuchungsPositionen");

            migrationBuilder.DropForeignKey(
                name: "FK_Konten_BankLeitZahl_BankLeitZahlId",
                table: "Konten");

            migrationBuilder.DropForeignKey(
                name: "FK_Konten_Laendercodes_LaendercodeId",
                table: "Konten");

            migrationBuilder.DropTable(
                name: "PositionsTypen");

            migrationBuilder.DropIndex(
                name: "IX_BuchungsPositionen_PositionsTypId",
                table: "BuchungsPositionen");

            migrationBuilder.DropColumn(
                name: "PositionsTypId",
                table: "BuchungsPositionen");

            migrationBuilder.AlterColumn<int>(
                name: "LaendercodeId",
                table: "Konten",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Gültigkeit",
                table: "Konten",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "BankLeitZahlId",
                table: "Konten",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ExtKontoId",
                table: "Buchungen",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Konten_ExtKontoId",
                table: "Buchungen",
                column: "ExtKontoId",
                principalTable: "Konten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Konten_BankLeitZahl_BankLeitZahlId",
                table: "Konten",
                column: "BankLeitZahlId",
                principalTable: "BankLeitZahl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Konten_Laendercodes_LaendercodeId",
                table: "Konten",
                column: "LaendercodeId",
                principalTable: "Laendercodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Konten_ExtKontoId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Konten_BankLeitZahl_BankLeitZahlId",
                table: "Konten");

            migrationBuilder.DropForeignKey(
                name: "FK_Konten_Laendercodes_LaendercodeId",
                table: "Konten");

            migrationBuilder.AlterColumn<int>(
                name: "LaendercodeId",
                table: "Konten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Gültigkeit",
                table: "Konten",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankLeitZahlId",
                table: "Konten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionsTypId",
                table: "BuchungsPositionen",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExtKontoId",
                table: "Buchungen",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PositionsTypen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Absetzbar = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Steuersatz = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionsTypen", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuchungsPositionen_PositionsTypId",
                table: "BuchungsPositionen",
                column: "PositionsTypId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Konten_ExtKontoId",
                table: "Buchungen",
                column: "ExtKontoId",
                principalTable: "Konten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuchungsPositionen_PositionsTypen_PositionsTypId",
                table: "BuchungsPositionen",
                column: "PositionsTypId",
                principalTable: "PositionsTypen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Konten_BankLeitZahl_BankLeitZahlId",
                table: "Konten",
                column: "BankLeitZahlId",
                principalTable: "BankLeitZahl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Konten_Laendercodes_LaendercodeId",
                table: "Konten",
                column: "LaendercodeId",
                principalTable: "Laendercodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
