using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Apresentacao
{
    public partial class locaisContext : DbContext
    {
        public locaisContext()
        {
        }

        public locaisContext(DbContextOptions<locaisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Geolocalizado> Geolocalizado { get; set; }
        public virtual DbSet<Logradouro> Logradouro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=locais.sqlite3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.ToTable("bairro");

                entity.HasIndex(e => e.BairroId)
                    .HasName("indiceBairro")
                    .IsUnique();

                entity.Property(e => e.BairroId)
                    .HasColumnType("varchar ( 75 )")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar ( 100 )");
            });

            modelBuilder.Entity<Geolocalizado>(entity =>
            {
                entity.ToTable("geolocalizado");

                entity.HasIndex(e => e.GeolocalizadoId)
                    .HasName("indiceGeolocalizado");

                entity.Property(e => e.GeolocalizadoId)
                    .HasColumnType("varchar ( 10 )")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnName("latitude")
                    .HasColumnType("varchar ( 30 )");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnName("longitude")
                    .HasColumnType("varchar ( 30 )");
            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.ToTable("logradouro");

                entity.HasIndex(e => e.LogradouroId)
                    .HasName("indiceLogradouro");

                entity.Property(e => e.LogradouroId).ValueGeneratedNever();

                entity.Property(e => e.IdBairro)
                    .HasColumnName("idBairro")
                    .HasColumnType("varchar ( 75 )");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar ( 100 )");
            });
        }
    }
}
