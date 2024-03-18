using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLink.Auth.Domain.Entities;

namespace StockLink.Auth.Infrastructure.Persistences.Contexts.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<TbUsuario>
    {
        public void Configure(EntityTypeBuilder<TbUsuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__TB_USUAR__3214EC072D1E9654");

            builder.ToTable("TB_USUARIO");

            builder.Property(e => e.Pass).IsUnicode(false);
            builder.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Despacho)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.RolNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROL_USUARIO");
        }
    }
}