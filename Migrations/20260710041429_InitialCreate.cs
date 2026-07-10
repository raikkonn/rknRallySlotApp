using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SistemaPuntuacion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Abreviado = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Escuderia = table.Column<string>(type: "TEXT", nullable: false),
                    Palmares = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pruebas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCampeonato = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    NumEtapas = table.Column<int>(type: "INTEGER", nullable: false),
                    TramosPorEtapa = table.Column<int>(type: "INTEGER", nullable: false),
                    TiempoMaximo = table.Column<decimal>(type: "TEXT", nullable: false),
                    CampeonatoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruebas_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPrueba = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPiloto = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCoche = table.Column<int>(type: "INTEGER", nullable: false),
                    Dorsal = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Verificado = table.Column<bool>(type: "INTEGER", nullable: false),
                    PruebaId = table.Column<int>(type: "INTEGER", nullable: true),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CocheId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Coches_CocheId",
                        column: x => x.CocheId,
                        principalTable: "Coches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Pruebas_PruebaId",
                        column: x => x.PruebaId,
                        principalTable: "Pruebas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TiemposTramos",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "INTEGER", nullable: false),
                    Etapa = table.Column<int>(type: "INTEGER", nullable: false),
                    Tramo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tiempo = table.Column<decimal>(type: "TEXT", nullable: false),
                    InscripcionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposTramos", x => new { x.IdInscripcion, x.Etapa, x.Tramo });
                    table.ForeignKey(
                        name: "FK_TiemposTramos_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_Nombre",
                table: "Campeonatos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CocheId",
                table: "Inscripciones",
                column: "CocheId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdPrueba_Dorsal",
                table: "Inscripciones",
                columns: new[] { "IdPrueba", "Dorsal" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PilotoId",
                table: "Inscripciones",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PruebaId",
                table: "Inscripciones",
                column: "PruebaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Abreviado",
                table: "Pilotos",
                column: "Abreviado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Nombre",
                table: "Pilotos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_CampeonatoId",
                table: "Pruebas",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_IdCampeonato_Nombre",
                table: "Pruebas",
                columns: new[] { "IdCampeonato", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiemposTramos_InscripcionId",
                table: "TiemposTramos",
                column: "InscripcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiemposTramos");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Coches");

            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Pruebas");

            migrationBuilder.DropTable(
                name: "Campeonatos");
        }
    }
}
