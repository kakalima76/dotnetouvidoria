using System;
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
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlite("Data Source=locais.sqlite3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
               
        }
    }
}
