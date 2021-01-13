using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class AdicionandoCampoIBGE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IBGE",
                table: "Cidades",
                type: "CHAR(5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBGE",
                table: "Cidades");
        }
    }
}
