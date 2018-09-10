﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apresentacao.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDenuncia",
                columns: table => new
                {
                    idDenuncia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "varchar(15)", nullable: false),
                    categoria = table.Column<string>(type: "varchar(45)", nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    agente = table.Column<string>(type: "varchar(45)", nullable: false),
                    processo = table.Column<string>(type: "varchar(14)", nullable: true),
                    logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    cep = table.Column<string>(type: "varchar(10)", nullable: true),
                    lat = table.Column<string>(type: "varchar(15)", nullable: true),
                    lng = table.Column<string>(type: "varchar(15)", nullable: true),
                    respostaPadrao = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDenuncia", x => x.idDenuncia);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDenuncia");
        }
    }
}
