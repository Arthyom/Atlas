using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class EditingPropertiesAndAddingOneToOneRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCodeOrigin",
                table: "Direccion",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "StreetOrigin",
                table: "Direccion",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "StateOrigin",
                table: "Direccion",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ReferencesOrigin",
                table: "Direccion",
                newName: "References");

            migrationBuilder.RenameColumn(
                name: "PhoneOrigin",
                table: "Direccion",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "OutdoorNumberOrigin",
                table: "Direccion",
                newName: "OutdoorNumber");

            migrationBuilder.RenameColumn(
                name: "NeighborhoodOrigin",
                table: "Direccion",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "NameOrigin",
                table: "Direccion",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "InteriorNumberOrigin",
                table: "Direccion",
                newName: "InteriorNumber");

            migrationBuilder.RenameColumn(
                name: "EmailOrigin",
                table: "Direccion",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CompanyOrigin",
                table: "Direccion",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "CityOrigin",
                table: "Direccion",
                newName: "City");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Order",
                type: "varchar(4)",
                unicode: false,
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiCustomerId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.UniqueConstraint("AK_Customer_ApiCustomerId", x => x.ApiCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductoOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoOrder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApiCustomerId",
                table: "Order",
                column: "ApiCustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_ApiCustomerId",
                table: "Order",
                column: "ApiCustomerId",
                principalTable: "Customer",
                principalColumn: "ApiCustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_ApiCustomerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ProductoOrder");

            migrationBuilder.DropIndex(
                name: "IX_Order_ApiCustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Direccion",
                newName: "ZipCodeOrigin");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Direccion",
                newName: "StreetOrigin");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Direccion",
                newName: "StateOrigin");

            migrationBuilder.RenameColumn(
                name: "References",
                table: "Direccion",
                newName: "ReferencesOrigin");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Direccion",
                newName: "PhoneOrigin");

            migrationBuilder.RenameColumn(
                name: "OutdoorNumber",
                table: "Direccion",
                newName: "OutdoorNumberOrigin");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "Direccion",
                newName: "NeighborhoodOrigin");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Direccion",
                newName: "NameOrigin");

            migrationBuilder.RenameColumn(
                name: "InteriorNumber",
                table: "Direccion",
                newName: "InteriorNumberOrigin");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Direccion",
                newName: "EmailOrigin");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Direccion",
                newName: "CompanyOrigin");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Direccion",
                newName: "CityOrigin");
        }
    }
}
