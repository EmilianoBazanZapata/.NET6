using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AgregandoPermitidoDeNulosEnlaLlaveForaneUsuarioDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                unique: true,
                filter: "[DetalleUsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 123,
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios",
                column: "DetalleUsuarioId",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
