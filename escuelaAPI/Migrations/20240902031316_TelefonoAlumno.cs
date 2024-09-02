using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escuelaAPI.Migrations
{
    /// <inheritdoc />
    public partial class TelefonoAlumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Alumno");
        }
    }
}
