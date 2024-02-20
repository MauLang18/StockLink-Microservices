using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Interfaces
{
    public interface ICotizacionRepository : IGenericRepository<Cotizaciones>
    {
        Task<BaseEntityResponse<Cotizaciones>> ListCotizaciones(BaseFiltersRequest filters);
        Task<Cotizaciones> FirstCotizacionByClienteVendedor(string cliente, string vendedor, string fecha);
    }
}