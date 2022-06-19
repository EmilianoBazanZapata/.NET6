using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RenombrarTablayColumnaArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "Articulos",
                newName: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tbl_Articulo",
                newName: "TituloArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo",
                column: "ArticuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo");

            migrationBuilder.RenameTable(
                name: "Tbl_Articulo",
                newName: "Articulos");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "Articulos",
                newName: "Titulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "ArticuloId");
        }
    }
}
