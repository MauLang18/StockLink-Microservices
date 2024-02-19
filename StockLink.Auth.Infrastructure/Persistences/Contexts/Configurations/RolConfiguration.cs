using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLink.Auth.Domain.Entities;

namespace StockLink.Auth.Infrastructure.Persistences.Contexts.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<TbRol>
    {
        public void Configure(EntityTypeBuilder<TbRol> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__TB_ROL__3214EC078E4D9A19");

            builder.ToTable("TB_ROL");

            builder.Property(e => e.Privilegios).IsUnicode(false);
            builder.Property(e => e.Rol)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}