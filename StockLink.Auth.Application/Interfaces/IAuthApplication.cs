using StockLink.Auth.Application.Commons.Bases;
using StockLink.Auth.Application.Dtos.Usuario.Request;

namespace StockLink.Auth.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<BaseResponse<string>> Login(TokenRequestDto requestDto);
    }
}