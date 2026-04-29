using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelatedEtiquetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtiquetaId",
                table: "Etiqueta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Etiqueta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etiqueta_EtiquetaId",
                table: "Etiqueta",
                column: "EtiquetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etiqueta_Etiqueta_EtiquetaId",
                table: "Etiqueta",
                column: "EtiquetaId",
                principalTable: "Etiqueta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etiqueta_Etiqueta_EtiquetaId",
                table: "Etiqueta");

            migrationBuilder.DropIndex(
                name: "IX_Etiqueta_EtiquetaId",
                table: "Etiqueta");

            migrationBuilder.DropColumn(
                name: "EtiquetaId",
                table: "Etiqueta");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Etiqueta");
        }
    }
}
