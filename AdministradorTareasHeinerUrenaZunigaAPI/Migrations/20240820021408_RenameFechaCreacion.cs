using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministradorTareasHeinerUrenaZunigaAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameFechaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Tareas",
                newName: "FechaInicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Tareas",
                newName: "FechaCreacion");
        }
    }
}
