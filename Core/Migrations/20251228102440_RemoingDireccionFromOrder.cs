using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoingDireccionFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Direccion_DireccionId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DireccionId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
