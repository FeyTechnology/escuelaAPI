using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escuelaAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdEstadoAlumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Alumno");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_EstadoId",
                table: "Alumno",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Estado_EstadoId",
                table: "Alumno",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Estado_EstadoId",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_EstadoId",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Alumno");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
