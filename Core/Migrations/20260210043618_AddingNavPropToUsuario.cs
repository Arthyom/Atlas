using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingNavPropToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrigenId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Info",
                table: "Guide",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_OrigenId",
                table: "Usuario",
                column: "OrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Origen_OrigenId",
                table: "Usuario",
                column: "OrigenId",
                principalTable: "Origen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Origen_OrigenId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_OrigenId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "OrigenId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Guide");
        }
    }
}
