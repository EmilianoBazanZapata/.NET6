using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CorrigiendoElNombreDeLaTablaArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_ArticuloId",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_Categorias_CategoriaID",
                table: "Tbl_Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo");

            migrationBuilder.RenameTable(
                name: "Tbl_Articulo",
                newName: "Articulos");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Articulo_CategoriaID",
                table: "Articulos",
                newName: "IX_Articulos_CategoriaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_ArticuloId",
                table: "ArticuloEtiqueta",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Categorias_CategoriaID",
                table: "Articulos",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_ArticuloId",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Categorias_CategoriaID",
                table: "Articulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "Articulos",
                newName: "Tbl_Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_CategoriaID",
                table: "Tbl_Articulo",
                newName: "IX_Tbl_Articulo_CategoriaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_ArticuloId",
                table: "ArticuloEtiqueta",
                column: "ArticuloId",
                principalTable: "Tbl_Articulo",
                principalColumn: "ArticuloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Articulo_Categorias_CategoriaID",
                table: "Tbl_Articulo",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
