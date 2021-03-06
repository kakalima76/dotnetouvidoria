﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;

namespace Apresentacao.Migrations.locais
{
    [DbContext(typeof(locaisContext))]
    partial class locaisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rio.SMF.CCU.Ouvidoria.Dominio.Models.Bairro", b =>
                {
                    b.Property<string>("BairroId")
                        .HasColumnName("bairroId")
                        .HasColumnType("varchar ( 75 )");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar ( 100 )");

                    b.HasKey("BairroId");

                    b.HasIndex("BairroId")
                        .IsUnique()
                        .HasName("indiceBairro");

                    b.ToTable("bairro");
                });

            modelBuilder.Entity("Rio.SMF.CCU.Ouvidoria.Dominio.Models.Geolocalizado", b =>
                {
                    b.Property<string>("GeolocalizadoId")
                        .HasColumnName("cep")
                        .HasColumnType("varchar ( 10 )");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnName("latitude")
                        .HasColumnType("varchar ( 30 )");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnName("longitude")
                        .HasColumnType("varchar ( 30 )");

                    b.HasKey("GeolocalizadoId");

                    b.HasIndex("GeolocalizadoId")
                        .HasName("indiceGeolocalizado");

                    b.ToTable("geolocalizado");
                });

            modelBuilder.Entity("Rio.SMF.CCU.Ouvidoria.Dominio.Models.Logradouro", b =>
                {
                    b.Property<long>("LogradouroId")
                        .HasColumnName("LogradouroId");

                    b.Property<string>("IdBairro")
                        .IsRequired()
                        .HasColumnName("idBairro")
                        .HasColumnType("varchar ( 75 )");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar ( 100 )");

                    b.HasKey("LogradouroId");

                    b.HasIndex("LogradouroId")
                        .HasName("indiceLogradouro");

                    b.ToTable("logradouro");
                });
#pragma warning restore 612, 618
        }
    }
}
