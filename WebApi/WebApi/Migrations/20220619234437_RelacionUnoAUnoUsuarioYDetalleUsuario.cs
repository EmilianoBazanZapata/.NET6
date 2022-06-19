using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RelacionUnoAUnoUsuarioYDetalleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DetalleUsuarioId",
                table: "Usuarios");
        }
    }
}
