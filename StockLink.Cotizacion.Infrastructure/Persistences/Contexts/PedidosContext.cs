using Microsoft.EntityFrameworkCore;
using StockLink.Cotizacion.Domain.Entities;
using System.Reflection;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Contexts
{
    public partial class PedidosContext : DbContext
    {
        public PedidosContext()
        {
        }

        public PedidosContext(DbContextOptions<PedidosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cotizaciones> Cotizacions { get; set; }

        public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational.Collaction", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}