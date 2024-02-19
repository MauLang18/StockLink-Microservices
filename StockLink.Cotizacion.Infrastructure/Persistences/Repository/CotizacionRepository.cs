using Microsoft.EntityFrameworkCore;
using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;
using StockLink.Cotizacion.Infrastructure.Persistences.Contexts;
using StockLink.Cotizacion.Infrastructure.Persistences.Interfaces;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Repository
{
    public class CotizacionRepository : GenericRepository<Cotizaciones>, ICotizacionRepository
    {
        private readonly PedidosContext _context;
        public CotizacionRepository(PedidosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Cotizaciones>> ListCotizaciones(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Cotizaciones>();

            var empresas = GetEntityQuery()
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        empresas = empresas.Where(x => x.Cliente!.Contains(filters.TextFilter));
                        break;
                }
            }

            filters.Sort ??= "Id";

            response.TotalRecords = await empresas.CountAsync();
            response.Items = await Ordering(filters, empresas, !(bool)filters.Download!).ToListAsync();

            return response;
        }
    }
}