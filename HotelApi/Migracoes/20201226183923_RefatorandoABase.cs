using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelApi.migracoes
{
    public partial class RefatorandoABase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Clientes",
                newName: "TelefoneCelular");

            migrationBuilder.RenameColumn(
                name: "ClienteStatus",
                table: "Clientes",
                newName: "PessoaId");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TelefonePrincipal",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneSecundario",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCadastro = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "NOW()"),
                    Cep = table.Column<string>(maxLength: 11, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(maxLength: 30, nullable: false),
                    Complemento = table.Column<string>(maxLength: 30, nullable: true),
                    CidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCadastro = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "NOW()"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Documento = table.Column<string>(type: "CHAR(15)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(70)", nullable: false),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCadastro = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "NOW()"),
                    PessoaId = table.Column<int>(nullable: false),
                    DataAdmissao = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    DataDemissao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_EnderecoId",
                table: "Hotels",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_PessoaId",
                table: "Funcionarios",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pessoas_PessoaId",
                table: "Clientes",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Enderecos_EnderecoId",
                table: "Hotels",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pessoas_PessoaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Enderecos_EnderecoId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_EnderecoId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "TelefonePrincipal",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "TelefoneSecundario",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "TelefoneCelular",
                table: "Clientes",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Clientes",
                newName: "ClienteStatus");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "VARCHAR(70)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "VARCHAR(60)",
                nullable: false,
                defaultValue: "");
        }
    }
}
