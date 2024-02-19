using AutoMapper;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Request;
using StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response;
using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Application.Mappers
{
    public class DetalleCotizacionMappingProfile : Profile
    {
        public DetalleCotizacionMappingProfile()
        {
            CreateMap<DetalleCotizacion, DetalleCotizacionResponseDto>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<DetalleCotizacion>, BaseEntityResponse<DetalleCotizacionResponseDto>>()
                .ReverseMap();
            CreateMap<DetalleCotizacion, ReportCotizacionResponseDto>()
                .ForMember(x => x.CodigoCliente, x => x.MapFrom(y => y.CotizacionNavigation.CodigoCliente))
                .ForMember(x => x.Cliente, x => x.MapFrom(y => y.CotizacionNavigation.Cliente))
                .ForMember(x => x.Vendedor, x => x.MapFrom(y => y.CotizacionNavigation.Vendedor))
                .ForMember(x => x.Descuento, x => x.MapFrom(y => y.CotizacionNavigation.Descuento))
                .ReverseMap();
            CreateMap<DetalleCotizacionRequestDto, DetalleCotizacion>()
                .ReverseMap();
        }
    }
}