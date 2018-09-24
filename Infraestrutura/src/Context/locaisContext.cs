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

        public virtual DbSet<Bairro> bairro { get; set; }
        public virtual DbSet<Geolocalizado> geolocalizado { get; set; }
        public virtual DbSet<Logradouro> Logralogradouro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                 string connectionStringBuilder = new
                SqliteConnectionStringBuilder()
                {
                    DataSource = "locais.sqlite3"
                }
                .ToString();

             var connection = new SqliteConnection(connectionStringBuilder);

                optionsBuilder.UseSqlite(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
               
        }
    }
}
