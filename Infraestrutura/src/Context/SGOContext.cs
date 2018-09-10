using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps;


namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context
{
    public class SGOContext : DbContext
    {
        public SGOContext(DbContextOptions<SGOContext> options) : base(options)
        {
            
        }

        public DbSet<Denuncia> Denuncias { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SGO;User ID=sa;Password=Ni244265;", b => b.MigrationsAssembly("Apresentacao")); 
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Denuncia>().ToTable("tblDenuncia");
            modelBuilder.ApplyConfiguration(new DenunciaMap()); 
        }
    }
}