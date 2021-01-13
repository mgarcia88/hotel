using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class AlterandoRelacionamentoPessoaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pessoas");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pessoas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Enderecos_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
