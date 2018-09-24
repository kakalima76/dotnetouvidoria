using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context
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
                string connectionStringBuilder = new
                SqliteConnectionStringBuilder()
                {
                    DataSource = "locais.sqlite3"
                }
                .ToString();

                var connection = new SqliteConnection(connectionStringBuilder);

            optionsBuilder.UseSqlite(connection, b => b.MigrationsAssembly("Apresentacao"));
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bairro>().ToTable("bairro");
            modelBuilder.ApplyConfiguration(new BairroMap());
            modelBuilder.Entity<Logradouro>().ToTable("logradouro");
            modelBuilder.ApplyConfiguration(new LogradouroMap());
            modelBuilder.Entity<Geolocalizado>().ToTable("geolocalizado");
            modelBuilder.ApplyConfiguration(new GeolocalizadoMap());    
        }
    }
}
