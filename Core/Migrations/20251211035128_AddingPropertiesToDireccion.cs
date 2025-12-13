using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingPropertiesToDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Order",
                newName: "DireccionId");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Direccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Direccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "Direccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DireccionId",
                table: "Order",
                column: "DireccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Direccion_DireccionId",
                table: "Order",
                column: "DireccionId",
                principalTable: "Direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Direccion_DireccionId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DireccionId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "Direccion");

            migrationBuilder.RenameColumn(
                name: "DireccionId",
                table: "Order",
                newName: "AddressId");
        }
    }
}
