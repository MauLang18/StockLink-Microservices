using AutoMapper;
using StockLink.Auth.Application.Dtos.Rol.Request;
using StockLink.Auth.Application.Dtos.Rol.Response;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Application.Mappers
{
    public class RolMappingsProfile : Profile
    {
        public RolMappingsProfile()
        {
            CreateMap<TbRol, RolResponseDto>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<TbRol>, BaseEntityResponse<RolResponseDto>>()
                .ReverseMap();
            CreateMap<RolRequestDto, TbRol>()
                .ReverseMap();
            CreateMap<TbRol, RolSelectResponseDto>()
                .ReverseMap();
        }
    }
}