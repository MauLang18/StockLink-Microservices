using Microsoft.Extensions.Configuration;
using StockLink.Cotizacion.Infrastructure.Persistences.Contexts;
using StockLink.Cotizacion.Infrastructure.Persistences.Interfaces;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PedidosContext _context;

        public ICotizacionRepository Cotizacion { get; private set; }

        public IDetalleCotizacionRepository DetalleCotizacion { get; private set; }

        public UnitOfWork(PedidosContext context, IConfiguration configuration)
        {
            _context = context;
            Cotizacion = new CotizacionRepository(_context);
            DetalleCotizacion = new DetalleCotizacionRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}