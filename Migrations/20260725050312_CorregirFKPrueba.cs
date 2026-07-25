using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class CorregirFKPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pruebas_Campeonatos_CampeonatoId",
                table: "Pruebas");

            migrationBuilder.DropIndex(
                name: "IX_Pruebas_CampeonatoId",
                table: "Pruebas");

            migrationBuilder.DropColumn(
                name: "CampeonatoId",
                table: "Pruebas");

            migrationBuilder.AddForeignKey(
                name: "FK_Pruebas_Campeonatos_IdCampeonato",
                table: "Pruebas",
                column: "IdCampeonato",
                principalTable: "Campeonatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pruebas_Campeonatos_IdCampeonato",
                table: "Pruebas");

            migrationBuilder.AddColumn<int>(
                name: "CampeonatoId",
                table: "Pruebas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_CampeonatoId",
                table: "Pruebas",
                column: "CampeonatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pruebas_Campeonatos_CampeonatoId",
                table: "Pruebas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id");
        }
    }
}
