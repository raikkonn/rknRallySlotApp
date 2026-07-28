using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class Modificacion_Pilotos_coches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Palmares",
                table: "Pilotos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Palmares",
                table: "Pilotos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
