using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingEtiquetaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiqueta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    PrecioMayoreo = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    Existencia = table.Column<byte>(type: "tinyint", nullable: false),
                    ExistenciaMinima = table.Column<byte>(type: "tinyint", nullable: false),
                    ExistenciaMaxima = table.Column<byte>(type: "tinyint", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etiqueta_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etiqueta_ModeloId",
                table: "Etiqueta",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etiqueta");
        }
    }
}
