using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingNavPropsToOrderAndEnvio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnvioId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Envio_OrderId",
                table: "Envio",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Order_OrderId",
                table: "Envio",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Order_OrderId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_OrderId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "EnvioId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Envio");
        }
    }
}
