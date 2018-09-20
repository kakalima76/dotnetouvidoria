using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Migrations.User
{
    public partial class acessoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "tblUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tblUsuario",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "tblUsuario",
                type: "varchar(45)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tblUsuario",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "tblUsuario");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "tblUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tblUsuario",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "tblUsuario",
                type: "varchar(MAX)",
                nullable: true);
        }
    }
}
