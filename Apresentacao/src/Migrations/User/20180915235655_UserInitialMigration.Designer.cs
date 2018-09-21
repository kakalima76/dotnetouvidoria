﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;

namespace Apresentacao.Migrations.User
{
    [DbContext(typeof(UserContext))]
    [Migration("20180915235655_UserInitialMigration")]
    partial class UserInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rio.SMF.CCU.Ouvidoria.Dominio.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(45)");

                    b.HasKey("UsuarioId");

                    b.ToTable("tblUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}