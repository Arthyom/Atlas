using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingModelosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    PrecioMayoreo = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    Existencia = table.Column<byte>(type: "tinyint", nullable: false),
                    Talla = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Color = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Genero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ExistenciaMinima = table.Column<byte>(type: "tinyint", nullable: false),
                    ExistenciaMaxima = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelo_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagenModelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenId = table.Column<int>(type: "int", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenModelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenModelo_Imagen_ImagenId",
                        column: x => x.ImagenId,
                        principalTable: "Imagen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagenModelo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenModelo_ImagenId",
                table: "ImagenModelo",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenModelo_ModeloId",
                table: "ImagenModelo",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_ProductoId",
                table: "Modelo",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenModelo");

            migrationBuilder.DropTable(
                name: "Modelo");
        }
    }
}
