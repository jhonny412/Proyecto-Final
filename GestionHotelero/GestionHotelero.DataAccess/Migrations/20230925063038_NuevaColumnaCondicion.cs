using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionHotelero.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NuevaColumnaCondicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombres",
                table: "Clientes",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Clientes",
                newName: "Apellido");

            migrationBuilder.AddColumn<bool>(
                name: "Condicion",
                table: "Habitaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Condicion",
                table: "Empleados",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Condicion",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NroDocumento",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 1,
                column: "Condicion",
                value: false);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 2,
                column: "Condicion",
                value: false);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 3,
                column: "Condicion",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condicion",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "Condicion",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Condicion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Clientes",
                newName: "Nombres");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Clientes",
                newName: "Apellidos");
        }
    }
}
