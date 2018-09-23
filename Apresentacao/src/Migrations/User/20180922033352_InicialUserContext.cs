using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Migrations.User
{
    public partial class InicialUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Password = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "varchar(45)", nullable: true),
                    Status = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuario", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUsuario");
        }
    }
}
