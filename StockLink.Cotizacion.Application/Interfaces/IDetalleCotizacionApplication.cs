using StockLink.Cotizacion.Application.Commons.Bases;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Request;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Application.Interfaces
{
    public interface IDetalleCotizacionApplication
    {
        Task<BaseResponse<BaseEntityResponse<DetalleCotizacionResponseDto>>> ListDetallesCotizaciones(BaseFiltersRequest filters);
        Task<BaseResponse<DetalleCotizacionResponseDto>> DetalleCotizacionById(int id);
        Task<BaseResponse<IEnumerable<ReportCotizacionResponseDto>>> ReportCotizacion(int id);
        Task<BaseResponse<bool>> RegisterDetalleCotizacion(DetalleCotizacionRequestDto requestDto);
        Task<BaseResponse<bool>> EditDetalleCotizacion(int id, DetalleCotizacionRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveDetalleCotizacion(int id);
    }
}