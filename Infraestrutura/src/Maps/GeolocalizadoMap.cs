using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;

namespace Rio.SMF.CCU.Ouvidoria.Infraestrutura.Maps
{
    public class GeolocalizadoMap : IEntityTypeConfiguration<Geolocalizado>
    {
        void IEntityTypeConfiguration<Geolocalizado>.Configure(EntityTypeBuilder<Geolocalizado> builder)
        {
            
            builder.HasKey(e => e.GeolocalizadoId);

            builder.ToTable("geolocalizado");

            builder.HasIndex(e => e.GeolocalizadoId)
                    .HasName("indiceGeolocalizado");

            builder.Property(e => e.GeolocalizadoId)
                    .HasColumnName("cep")
                    .HasColumnType("varchar ( 10 )")
                    .ValueGeneratedNever();

            builder.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnName("latitude")
                    .HasColumnType("varchar ( 30 )");

            builder.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnName("longitude")
                    .HasColumnType("varchar ( 30 )");
                       
          
        }
    }
}