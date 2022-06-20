using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CorrigiendoElNombreDeLaTablaEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_Etiqueta_ID",
                table: "ArticuloEtiqueta");

            migrationBuilder.RenameColumn(
                name: "Etiqueta_ID",
                table: "Etiquetas",
                newName: "EtiquetaID");

            migrationBuilder.RenameColumn(
                name: "Etiqueta_ID",
                table: "ArticuloEtiqueta",
                newName: "EtiquetaID");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Etiquetas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaID",
                table: "ArticuloEtiqueta",
                column: "EtiquetaID",
                principalTable: "Etiquetas",
                principalColumn: "EtiquetaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaID",
                table: "ArticuloEtiqueta");

            migrationBuilder.RenameColumn(
                name: "EtiquetaID",
                table: "Etiquetas",
                newName: "Etiqueta_ID");

            migrationBuilder.RenameColumn(
                name: "EtiquetaID",
                table: "ArticuloEtiqueta",
                newName: "Etiqueta_ID");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Etiquetas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_Etiqueta_ID",
                table: "ArticuloEtiqueta",
                column: "Etiqueta_ID",
                principalTable: "Etiquetas",
                principalColumn: "Etiqueta_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
