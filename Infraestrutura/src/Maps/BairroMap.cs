using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps
{
    public class BairroMap : IEntityTypeConfiguration<Bairro>
    {
        void IEntityTypeConfiguration<Bairro>.Configure(EntityTypeBuilder<Bairro> builder)
        {

            builder
           .HasKey(e => e.BairroId);
            
            builder
            .ToTable("bairro");

            builder.HasIndex(e => e.BairroId)
                    .HasName("indiceBairro")
                    .IsUnique();

            builder.Property(e => e.BairroId)
                    .HasColumnName("bairroId")
                    .HasColumnType("varchar ( 75 )")
                    .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar ( 100 )");
           
        }
    }
}