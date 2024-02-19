using StockLink.Auth.Application.Commons.Bases;
using StockLink.Auth.Application.Dtos.Usuario.Request;
using StockLink.Auth.Application.Dtos.Usuario.Response;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<BaseResponse<BaseEntityResponse<UsuarioResponseDto>>> ListUsuarios(BaseFiltersRequest filters);
        Task<BaseResponse<UsuarioByIdResponseDto>> UsuarioById(int id);
        Task<BaseResponse<UsuarioByIdResponseDto>> UsuarioByUser(string user);
        Task<BaseResponse<bool>> RegisterUsuario(UsuarioRequestDto requestDto);
        Task<BaseResponse<bool>> EditUsuario(int id, UsuarioRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveUsuario(int id);
    }
}