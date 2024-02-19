using StockLink.Cotizacion.Application.Commons.Bases;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Request;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Response;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Request;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Application.Interfaces
{
    public interface ICotizacionApplication
    {
        Task<BaseResponse<BaseEntityResponse<CotizacionResponseDto>>> ListCotizaciones(BaseFiltersRequest filters);
        Task<BaseResponse<CotizacionResponseDto>> CotizacionById(int id);
        Task<BaseResponse<bool>> RegisterCotizacion(CotizacionRequestDto requestDto);
        Task<BaseResponse<bool>> EditCotizacion(int id, CotizacionRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCotizacion(int id);
    }
}