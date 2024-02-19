using AutoMapper;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Request;
using StockLink.Cotizacion.Application.Dtos.Cotizacion.Response;
using StockLink.Cotizacion.Domain.Entities;
using StockLink.Cotizacion.Infrastructure.Commons.Bases.Response;

namespace StockLink.Cotizacion.Application.Mappers
{
    public class CotizacionMappingProfile : Profile
    {
        public CotizacionMappingProfile()
        {
            CreateMap<Cotizaciones, CotizacionResponseDto>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<Cotizaciones>, BaseEntityResponse<CotizacionResponseDto>>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<Cotizaciones>, BaseEntityResponse<CotizacionResponseDto>>()
                .ReverseMap();
            CreateMap<CotizacionRequestDto, Cotizaciones>()
                .ReverseMap();
        }
    }
}