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
            optionsBuilder.UseSqlServer("Server=tcp:dotnet-ouvidoria.database.windows.net,1433;Initial Catalog=SGO;Persist Security Info=False;User ID=kakalima76;Password=Ni244265;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("Apresentacao")); 
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Denuncia>().ToTable("tblDenuncia");
            modelBuilder.ApplyConfiguration(new DenunciaMap()); 
        }
    }
}