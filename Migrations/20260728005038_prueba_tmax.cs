using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rknRallySlotApp.Migrations
{
    /// <inheritdoc />
    public partial class prueba_tmax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TiempoMaximo",
                table: "Pruebas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TiempoMaximo",
                table: "Pruebas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
