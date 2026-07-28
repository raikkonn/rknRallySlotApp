using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class Pilotos_Alias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Abreviado",
                table: "Pilotos",
                newName: "Alias");

            migrationBuilder.RenameIndex(
                name: "IX_Pilotos_Abreviado",
                table: "Pilotos",
                newName: "IX_Pilotos_Alias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "Pilotos",
                newName: "Abreviado");

            migrationBuilder.RenameIndex(
                name: "IX_Pilotos_Alias",
                table: "Pilotos",
                newName: "IX_Pilotos_Abreviado");
        }
    }
}
