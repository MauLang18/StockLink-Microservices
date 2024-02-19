using AutoMapper;
using StockLink.Auth.Application.Dtos.Usuario.Request;
using StockLink.Auth.Application.Dtos.Usuario.Response;
using StockLink.Auth.Domain.Entities;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Application.Mappers
{
    public class UsuarioMappingsProfile : Profile
    {
        public UsuarioMappingsProfile()
        {
            CreateMap<TbUsuario, UsuarioResponseDto>()
                .ForMember(x => x.Rol, x => x.MapFrom(y => y.RolNavigation.Rol))
                .ReverseMap();
            CreateMap<TbUsuario, UsuarioByIdResponseDto>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<TbUsuario>, BaseEntityResponse<UsuarioResponseDto>>()
                .ReverseMap();
            CreateMap<UsuarioRequestDto, TbUsuario>()
                .ReverseMap();
            CreateMap<TokenRequestDto, TbUsuario>();
        }
    }
}