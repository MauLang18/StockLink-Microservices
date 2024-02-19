using MediatR;
using StockLink.Softland.Application.Dto.Cliente.Response;
using StockLink.Softland.Application.UseCase.Commons.Bases;

namespace StockLink.Softland.Application.UseCase.UseCase.Cliente.Queries.GetAllQuery
{
    public class GetAllClienteQuery : IRequest<BaseResponse<IEnumerable<GetAllClienteResponseDto>>>
    {
        public string? CLIE { get; set; }
    }
}