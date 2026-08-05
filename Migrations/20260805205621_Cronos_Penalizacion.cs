using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class Cronos_Penalizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiemposTramos");

            migrationBuilder.AddColumn<int>(
                name: "PenalizacionSEG",
                table: "Inscripciones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cronos",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "INTEGER", nullable: false),
                    Etapa = table.Column<int>(type: "INTEGER", nullable: false),
                    Tramo = table.Column<int>(type: "INTEGER", nullable: false),
                    CronoMS = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronos", x => new { x.IdInscripcion, x.Etapa, x.Tramo });
                    table.ForeignKey(
                        name: "FK_Cronos_Inscripciones_IdInscripcion",
                        column: x => x.IdInscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cronos");

            migrationBuilder.DropColumn(
                name: "PenalizacionSEG",
                table: "Inscripciones");

            migrationBuilder.CreateTable(
                name: "TiemposTramos",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "INTEGER", nullable: false),
                    Etapa = table.Column<int>(type: "INTEGER", nullable: false),
                    Tramo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tiempo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposTramos", x => new { x.IdInscripcion, x.Etapa, x.Tramo });
                    table.ForeignKey(
                        name: "FK_TiemposTramos_Inscripciones_IdInscripcion",
                        column: x => x.IdInscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
