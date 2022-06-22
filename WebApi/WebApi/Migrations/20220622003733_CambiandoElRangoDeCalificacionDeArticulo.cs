using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CambiandoElRangoDeCalificacionDeArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
