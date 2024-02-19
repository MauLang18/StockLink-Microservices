using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLink.Cotizacion.Domain.Entities;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Contexts.Configurations
{
    public class DetalleCotizacionConfiguration : IEntityTypeConfiguration<DetalleCotizacion>
    {
        public void Configure(EntityTypeBuilder<DetalleCotizacion> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("DETALLE_COTIZACION");

            builder.HasOne(d => d.CotizacionNavigation)
                .WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdCotizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COTIZACION_DETALLE_COTIZACION");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CodigoArticulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Articulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Precio)
                .HasColumnType("decimal(10,2)");
        }
    }
}