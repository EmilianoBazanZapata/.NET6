using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RelacionCategoriaArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "Categoria_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tbl_Articulo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria_ID",
                table: "Tbl_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Articulo_Categoria_ID",
                table: "Tbl_Articulo",
                column: "Categoria_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Articulo_Categorias_Categoria_ID",
                table: "Tbl_Articulo",
                column: "Categoria_ID",
                principalTable: "Categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_Categorias_Categoria_ID",
                table: "Tbl_Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Articulo_Categoria_ID",
                table: "Tbl_Articulo");

            migrationBuilder.DropColumn(
                name: "Categoria_ID",
                table: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "Categoria_Id",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tbl_Articulo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
