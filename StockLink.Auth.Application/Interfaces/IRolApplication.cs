using StockLink.Auth.Application.Commons.Bases;
using StockLink.Auth.Application.Dtos.Rol.Request;
using StockLink.Auth.Application.Dtos.Rol.Response;
using StockLink.Auth.Infrastructure.Commons.Bases.Request;
using StockLink.Auth.Infrastructure.Commons.Bases.Response;

namespace StockLink.Auth.Application.Interfaces
{
    public interface IRolApplication
    {
        Task<BaseResponse<BaseEntityResponse<RolResponseDto>>> ListRoles(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<RolSelectResponseDto>>> ListSelectRol();
        Task<BaseResponse<RolResponseDto>> RolById(int id);
        Task<BaseResponse<bool>> RegisterRol(RolRequestDto requestDto);
        Task<BaseResponse<bool>> EditRol(int id, RolRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveRol(int id);
    }
}