using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnFolioToVentaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalProductos",
                table: "Venta",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,0)");

            migrationBuilder.AddColumn<string>(
                name: "Folio",
                table: "Venta",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Folio",
                table: "Venta");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProductos",
                table: "Venta",
                type: "decimal(38,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
