using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class MakingNullableSomeNavPropsFromEnvio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Origen_OriginId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Paquete_PackageId",
                table: "Envio");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Envio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Envio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Origen_OriginId",
                table: "Envio",
                column: "OriginId",
                principalTable: "Origen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Paquete_PackageId",
                table: "Envio",
                column: "PackageId",
                principalTable: "Paquete",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Origen_OriginId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Paquete_PackageId",
                table: "Envio");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Origen_OriginId",
                table: "Envio",
                column: "OriginId",
                principalTable: "Origen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Paquete_PackageId",
                table: "Envio",
                column: "PackageId",
                principalTable: "Paquete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
