using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.migracoes
{
    public partial class AdicionandoRelacionamentoClienteHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Clientes");
        }
    }
}
