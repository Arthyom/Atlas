using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Categoria_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Info = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Imagen_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Permiso_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("NewTable_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
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
                    ExistenciaMinima = table.Column<byte>(type: "tinyint", nullable: false),
                    ExistenciaMaxima = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Producto_PK", x => x.Id);
                    table.ForeignKey(
                        name: "Producto_Categoria_FK",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RolPermiso_PK", x => x.Id);
                    table.ForeignKey(
                        name: "RolPermiso_Permiso_FK",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "RolPermiso_Rol_FK",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Usuario_PK", x => x.Id);
                    table.ForeignKey(
                        name: "Usuario_Rol_FK",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagenProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ImagenProducto_PK", x => x.Id);
                    table.ForeignKey(
                        name: "ImagenProducto_Imagen_FK",
                        column: x => x.ImagenId,
                        principalTable: "Imagen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ImagenProducto_Producto_FK",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenProducto_ImagenId",
                table: "ImagenProducto",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenProducto_ProductoId",
                table: "ImagenProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolId",
                table: "RolPermiso",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenProducto");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
