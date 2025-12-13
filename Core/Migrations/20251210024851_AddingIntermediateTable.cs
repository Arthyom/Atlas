using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingIntermediateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrder_OrderId",
                table: "ProductoOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrder_ProductoId",
                table: "ProductoOrder",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoOrder_Order_OrderId",
                table: "ProductoOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoOrder_Producto_ProductoId",
                table: "ProductoOrder",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoOrder_Order_OrderId",
                table: "ProductoOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoOrder_Producto_ProductoId",
                table: "ProductoOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductoOrder_OrderId",
                table: "ProductoOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductoOrder_ProductoId",
                table: "ProductoOrder");
        }
    }
}
