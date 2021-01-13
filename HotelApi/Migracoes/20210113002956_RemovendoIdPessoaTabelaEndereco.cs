using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class RemovendoIdPessoaTabelaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Enderecos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Enderecos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
