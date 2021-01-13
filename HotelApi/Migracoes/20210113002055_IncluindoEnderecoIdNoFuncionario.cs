using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class IncluindoEnderecoIdNoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Clientes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
