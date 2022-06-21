using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class SiembraDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Activo", "FechaCreacion", "Nombre" },
                values: new object[] { 123, true, new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), "Categoria Generada en el DbContext" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123);
        }
    }
}
