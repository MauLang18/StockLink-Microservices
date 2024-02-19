using Microsoft.EntityFrameworkCore;
using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;
using StockLink.Cotizacion.Infrastructure.Persistences.Contexts;
using StockLink.Cotizacion.Infrastructure.Persistences.Interfaces;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Repository
{
    public class DetalleCotizacionRepository : GenericRepository<DetalleCotizacion>, IDetalleCotizacionRepository
    {
        private readonly PedidosContext _context;
        public DetalleCotizacionRepository(PedidosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<DetalleCotizacion>> ListDetallesCotizaciones(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<DetalleCotizacion>();

            var usuarios = GetEntityQuery()
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        usuarios = usuarios.Where(x => x.Articulo!.Contains(filters.TextFilter));
                        break;
                }
            }

            filters.Sort ??= "Id";

            response.TotalRecords = await usuarios.CountAsync();
            response.Items = await Ordering(filters, usuarios, !(bool)filters.Download!).ToListAsync();

            return response;
        }

        public async Task<IEnumerable<DetalleCotizacion>> ListDetallesCotizacionesByCotizacion(int id)
        {
            var user = await _context.DetalleCotizacions.AsNoTracking()
                .Where(x => x.IdCotizacion == id)
                .Include(x => x.CotizacionNavigation)
                .ToListAsync();

            return user!;
        }
    }
}