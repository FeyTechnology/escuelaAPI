using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escuelaAPI.Migrations
{
    /// <inheritdoc />
    public partial class NullableMaternoAndDeleteTelefonoEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empleado");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
