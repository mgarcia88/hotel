using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class RemovendoCampoIBGE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBGE",
                table: "Cidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IBGE",
                table: "Cidades",
                type: "CHAR(5)",
                nullable: true);
        }
    }
}
