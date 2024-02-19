using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLink.Cotizacion.Domain.Entities;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Contexts.Configurations
{
    public class CotizacionesConfiguration : IEntityTypeConfiguration<Cotizaciones>
    {
        public void Configure(EntityTypeBuilder<Cotizaciones> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("COTIZACION");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CodigoCliente)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Vendedor)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Descuento)
                .HasColumnType("decimal(10,2)");
        }
    }
}