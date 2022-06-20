using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RelacionMuchosAMuchosEntreArticuloYEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    Articulo_Id = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.Etiqueta_ID, x.Articulo_Id });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiquetas_Etiqueta_ID",
                        column: x => x.Etiqueta_ID,
                        principalTable: "Etiquetas",
                        principalColumn: "Etiqueta_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                        column: x => x.Articulo_Id,
                        principalTable: "Tbl_Articulo",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");
        }
    }
}
