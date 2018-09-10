using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps
{
    public class LogradouroMap : IEntityTypeConfiguration<Logradouro>
    {
        void IEntityTypeConfiguration<Logradouro>.Configure(EntityTypeBuilder<Logradouro> builder)
        {
            builder.HasKey(e => e.LogradouroId);

            builder.ToTable("logradouro");

            builder.HasIndex(e => e.LogradouroId)
                    .HasName("indiceLogradouro");

            builder.Property(e => e.LogradouroId)
                    .HasColumnName("cep")
                    .ValueGeneratedNever();

            builder.Property(e => e.IdBairro)
                    .IsRequired()
                    .HasColumnName("idBairro")
                    .HasColumnType("varchar ( 75 )");

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar ( 100 )");
        }
    }
}