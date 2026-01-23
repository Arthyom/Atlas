using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewTableGuideAndConnecting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Envio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingProvider",
                table: "Envio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guide_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envio_GuideId",
                table: "Envio",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Guide_OrderId",
                table: "Guide",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Guide_GuideId",
                table: "Envio",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Guide_GuideId",
                table: "Envio");

            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.DropIndex(
                name: "IX_Envio_GuideId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "ShippingProvider",
                table: "Envio");
        }
    }
}
