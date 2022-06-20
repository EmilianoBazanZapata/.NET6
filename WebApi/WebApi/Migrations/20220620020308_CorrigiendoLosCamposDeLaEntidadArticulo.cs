using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CorrigiendoLosCamposDeLaEntidadArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_Categorias_Categoria_ID",
                table: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "Tbl_Articulo",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Categoria_ID",
                table: "Tbl_Articulo",
                newName: "CategoriaID");

            migrationBuilder.RenameColumn(
                name: "Articulo_Id",
                table: "Tbl_Articulo",
                newName: "ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Articulo_Categoria_ID",
                table: "Tbl_Articulo",
                newName: "IX_Tbl_Articulo_CategoriaID");

            migrationBuilder.RenameColumn(
                name: "Articulo_Id",
                table: "ArticuloEtiqueta",
                newName: "ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                newName: "IX_ArticuloEtiqueta_ArticuloId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tbl_Articulo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_ArticuloId",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_Categorias_CategoriaID",
                table: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tbl_Articulo",
                newName: "TituloArticulo");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "Tbl_Articulo",
                newName: "Categoria_ID");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Tbl_Articulo",
                newName: "Articulo_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Articulo_CategoriaID",
                table: "Tbl_Articulo",
                newName: "IX_Tbl_Articulo_Categoria_ID");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "ArticuloEtiqueta",
                newName: "Articulo_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiqueta_ArticuloId",
                table: "ArticuloEtiqueta",
                newName: "IX_ArticuloEtiqueta_Articulo_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tbl_Articulo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id",
                principalTable: "Tbl_Articulo",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Articulo_Categorias_Categoria_ID",
                table: "Tbl_Articulo",
                column: "Categoria_ID",
                principalTable: "Categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
