using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
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
                    Marca = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
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
                    Alias = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Escuderia = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
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
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NumEtapas = table.Column<int>(type: "INTEGER", nullable: false),
                    TramosPorEtapa = table.Column<int>(type: "INTEGER", nullable: false),
                    TiempoMaximo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruebas_Campeonatos_IdCampeonato",
                        column: x => x.IdCampeonato,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Verificado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Coches_IdCoche",
                        column: x => x.IdCoche,
                        principalTable: "Coches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Pilotos_IdPiloto",
                        column: x => x.IdPiloto,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Pruebas_IdPrueba",
                        column: x => x.IdPrueba,
                        principalTable: "Pruebas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_Nombre",
                table: "Campeonatos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdCoche",
                table: "Inscripciones",
                column: "IdCoche");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdPiloto",
                table: "Inscripciones",
                column: "IdPiloto");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdPrueba_Dorsal",
                table: "Inscripciones",
                columns: new[] { "IdPrueba", "Dorsal" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Alias",
                table: "Pilotos",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Nombre",
                table: "Pilotos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_IdCampeonato_Nombre",
                table: "Pruebas",
                columns: new[] { "IdCampeonato", "Nombre" },
                unique: true);
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
