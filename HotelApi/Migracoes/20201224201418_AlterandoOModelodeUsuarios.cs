using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApi.Migracoes
{
    public partial class AlterandoOModelodeUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuarios",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Usuarios",
                newName: "UserName");
        }
    }
}
