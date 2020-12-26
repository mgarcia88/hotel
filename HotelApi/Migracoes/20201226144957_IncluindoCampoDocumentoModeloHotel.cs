using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.Migracoes
{
    public partial class IncluindoCampoDocumentoModeloHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Hotels",
                type: "VARCHAR(15)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Hotels");
        }
    }
}
