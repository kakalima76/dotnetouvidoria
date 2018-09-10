using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps
{
    public class DenunciaMap : IEntityTypeConfiguration<Denuncia>
    {
        void IEntityTypeConfiguration<Denuncia>.Configure(EntityTypeBuilder<Denuncia> builder)
        {
            builder
            .HasKey(x => x.idDenuncia);

            builder
            .Property(x => x.tipo)
            .HasColumnType("varchar(15)");

            builder
            .Property(x => x.categoria)
            .HasColumnType("varchar(45)");

            builder
            .Property(x => x.agente)
            .HasColumnType("varchar(45)");

            builder
            .Property(x => x.processo)
            .HasColumnType("varchar(14)");

            builder
            .Property(x => x.logradouro)
            .HasColumnType("varchar(100)");

            builder
            .Property(x => x.bairro)
            .HasColumnType("varchar(50)");

            builder
            .Property(x => x.cep)
            .HasColumnType("varchar(10)");

            builder
            .Property(x => x.lat)
            .HasColumnType("varchar(15)");

            builder
            .Property(x => x.lng)
            .HasColumnType("varchar(15)");

            builder
            .Property(x => x.respostaPadrao)
            .HasColumnType("varchar(500)");

            builder
            .Property(x => x.complemento)
            .HasColumnType("varchar(50)");
        }
    }
}