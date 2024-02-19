using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Infrastructure.Persistences.Interfaces
{
    public interface IDetalleCotizacionRepository : IGenericRepository<DetalleCotizacion>
    {
        Task<BaseEntityResponse<DetalleCotizacion>> ListDetallesCotizaciones(BaseFiltersRequest filters);
        Task<IEnumerable<DetalleCotizacion>> ListDetallesCotizacionesByCotizacion(int id);
    }
}