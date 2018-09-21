﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;

namespace Apresentacao.Migrations
{
    [DbContext(typeof(SGOContext))]
    [Migration("20180914213242_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rio.SMF.CCU.Ouvidoria.Dominio.Models.Denuncia", b =>
                {
                    b.Property<int>("idDenuncia")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("agente")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("cep")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("complemento")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("data");

                    b.Property<string>("lat")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("lng")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("processo")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("respostaPadrao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("idDenuncia");

                    b.ToTable("tblDenuncia");
                });
#pragma warning restore 612, 618
        }
    }
}