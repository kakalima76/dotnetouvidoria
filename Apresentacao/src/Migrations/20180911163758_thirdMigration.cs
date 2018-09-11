using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "tblDenuncia",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numero",
                table: "tblDenuncia",
                type: "varchar(15)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numero",
                table: "tblDenuncia");

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "tblDenuncia",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
