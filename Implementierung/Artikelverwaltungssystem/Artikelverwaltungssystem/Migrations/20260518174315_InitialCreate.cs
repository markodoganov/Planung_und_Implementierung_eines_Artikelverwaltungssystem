using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artikelverwaltungssystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abteilungen",
                columns: table => new
                {
                    AbteilungsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abteilungen", x => x.AbteilungsID);
                });

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false),
                    Kategorie = table.Column<string>(type: "TEXT", nullable: false),
                    Seriennummer = table.Column<string>(type: "TEXT", nullable: false),
                    Inventarnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    AbteilungsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelID);
                });

            migrationBuilder.CreateTable(
                name: "Historien",
                columns: table => new
                {
                    HistorienID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelID = table.Column<int>(type: "INTEGER", nullable: false),
                    AlteAbteilung = table.Column<string>(type: "TEXT", nullable: false),
                    NeueAbteilung = table.Column<string>(type: "TEXT", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historien", x => x.HistorienID);
                });

            migrationBuilder.CreateTable(
                name: "Verbrauchsarten",
                columns: table => new
                {
                    VerbrauchsartID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbrauchsarten", x => x.VerbrauchsartID);
                });

            migrationBuilder.CreateTable(
                name: "Verbrauchsbuchungen",
                columns: table => new
                {
                    VerbrauchsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VerbrauchsartID = table.Column<int>(type: "INTEGER", nullable: false),
                    AbteilungsID = table.Column<int>(type: "INTEGER", nullable: false),
                    Menge = table.Column<int>(type: "INTEGER", nullable: false),
                    VerwendetAm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbrauchsbuchungen", x => x.VerbrauchsID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abteilungen");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Historien");

            migrationBuilder.DropTable(
                name: "Verbrauchsarten");

            migrationBuilder.DropTable(
                name: "Verbrauchsbuchungen");
        }
    }
}
