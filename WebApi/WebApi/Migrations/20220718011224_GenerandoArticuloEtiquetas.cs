using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class GenerandoArticuloEtiquetas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_ArticuloId",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaID",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticuloEtiqueta",
                table: "ArticuloEtiqueta");

            migrationBuilder.RenameTable(
                name: "ArticuloEtiqueta",
                newName: "ArticuloEtiquetas");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiqueta_ArticuloId",
                table: "ArticuloEtiquetas",
                newName: "IX_ArticuloEtiquetas_ArticuloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticuloEtiquetas",
                table: "ArticuloEtiquetas",
                columns: new[] { "EtiquetaID", "ArticuloId" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiquetas_Articulos_ArticuloId",
                table: "ArticuloEtiquetas",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiquetas_Etiquetas_EtiquetaID",
                table: "ArticuloEtiquetas",
                column: "EtiquetaID",
                principalTable: "Etiquetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiquetas_Articulos_ArticuloId",
                table: "ArticuloEtiquetas");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiquetas_Etiquetas_EtiquetaID",
                table: "ArticuloEtiquetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticuloEtiquetas",
                table: "ArticuloEtiquetas");

            migrationBuilder.RenameTable(
                name: "ArticuloEtiquetas",
                newName: "ArticuloEtiqueta");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiquetas_ArticuloId",
                table: "ArticuloEtiqueta",
                newName: "IX_ArticuloEtiqueta_ArticuloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticuloEtiqueta",
                table: "ArticuloEtiqueta",
                columns: new[] { "EtiquetaID", "ArticuloId" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 7, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_ArticuloId",
                table: "ArticuloEtiqueta",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaID",
                table: "ArticuloEtiqueta",
                column: "EtiquetaID",
                principalTable: "Etiquetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
