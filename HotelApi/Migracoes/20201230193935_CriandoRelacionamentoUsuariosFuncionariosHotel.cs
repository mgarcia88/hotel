using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class CriandoRelacionamentoUsuariosFuncionariosHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncionarioId",
                table: "Usuarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_HotelId",
                table: "Funcionarios",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Hotels_HotelId",
                table: "Funcionarios",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Funcionarios_FuncionarioId",
                table: "Usuarios",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Hotels_HotelId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Funcionarios_FuncionarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_FuncionarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_HotelId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Funcionarios");
        }
    }
}
