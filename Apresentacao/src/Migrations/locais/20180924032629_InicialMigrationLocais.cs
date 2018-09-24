using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Migrations.locais
{
    public partial class InicialMigrationLocais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bairro",
                columns: table => new
                {
                    bairroId = table.Column<string>(type: "varchar ( 75 )", nullable: false),
                    nome = table.Column<string>(type: "varchar ( 100 )", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bairro", x => x.bairroId);
                });

            migrationBuilder.CreateTable(
                name: "geolocalizado",
                columns: table => new
                {
                    cep = table.Column<string>(type: "varchar ( 10 )", nullable: false),
                    latitude = table.Column<string>(type: "varchar ( 30 )", nullable: false),
                    longitude = table.Column<string>(type: "varchar ( 30 )", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_geolocalizado", x => x.cep);
                });

            migrationBuilder.CreateTable(
                name: "logradouro",
                columns: table => new
                {
                    cep = table.Column<long>(nullable: false),
                    idBairro = table.Column<string>(type: "varchar ( 75 )", nullable: false),
                    nome = table.Column<string>(type: "varchar ( 100 )", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logradouro", x => x.cep);
                });

            migrationBuilder.CreateIndex(
                name: "indiceBairro",
                table: "bairro",
                column: "bairroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indiceGeolocalizado",
                table: "geolocalizado",
                column: "cep");

            migrationBuilder.CreateIndex(
                name: "indiceLogradouro",
                table: "logradouro",
                column: "cep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bairro");

            migrationBuilder.DropTable(
                name: "geolocalizado");

            migrationBuilder.DropTable(
                name: "logradouro");
        }
    }
}
