using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        void IEntityTypeConfiguration<Usuario>.Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
            .HasKey(x => x.UsuarioId);

            builder
            .Property(x => x.Nome)
            .HasColumnType("varchar(45)");

             builder
            .Property(x => x.ConfirmPassword)
            .HasColumnType("varchar(45)");

            builder
            .Property(x => x.Password)
            .HasColumnType("varchar(MAX)");

            builder
            .Property(x => x.Status)
            .HasColumnType("varchar(45)");
          
        }
    }
}