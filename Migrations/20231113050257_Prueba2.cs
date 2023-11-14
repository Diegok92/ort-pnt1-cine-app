using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineApp.Migrations
{
    /// <inheritdoc />
    public partial class Prueba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "Contraseña");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuarios",
                newName: "Apellido");
        }
    }
}
