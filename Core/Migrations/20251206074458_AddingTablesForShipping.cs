using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingTablesForShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorNumberOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutdoorNumberOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCodeOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeighborhoodOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencesOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id);
                    table.ForeignKey(
                        name: "Destino_Direccion_FK",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Origen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origen", x => x.Id);
                    table.ForeignKey(
                        name: "Origen_Direccion_FK",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envio_Destino_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envio_Origen_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envio_Paquete_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Paquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destino_DireccionId",
                table: "Destino",
                column: "DireccionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envio_DestinationId",
                table: "Envio",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_OriginId",
                table: "Envio",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_PackageId",
                table: "Envio",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Origen_DireccionId",
                table: "Origen",
                column: "DireccionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Envio");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Origen");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}
