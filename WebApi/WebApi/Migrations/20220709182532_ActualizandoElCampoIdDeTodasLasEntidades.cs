using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class ActualizandoElCampoIdDeTodasLasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EtiquetaID",
                table: "Etiquetas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Articulos",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Etiquetas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Etiquetas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Categorias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "Articulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Etiquetas");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Etiquetas");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Etiquetas",
                newName: "EtiquetaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articulos",
                newName: "ArticuloId");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
