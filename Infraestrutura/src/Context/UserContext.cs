using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps;


namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:dotnet-ouvidoria.database.windows.net,1433;Initial Catalog=ACESSO;User Id=kakalima76@dotnet-ouvidoria.database.windows.net;Password=Ni244265;", b => b.MigrationsAssembly("Apresentacao")); 
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("tblUsuario");
            modelBuilder.ApplyConfiguration(new UsuarioMap()); 
        }
    }
}