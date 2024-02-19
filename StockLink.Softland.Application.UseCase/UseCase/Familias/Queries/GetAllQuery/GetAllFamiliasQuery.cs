using MediatR;
using StockLink.Softland.Application.Dto.Familia.Response;
using StockLink.Softland.Application.UseCase.Commons.Bases;

namespace StockLink.Softland.Application.UseCase.UseCase.Familias.Queries.GetAllQuery
{
    public class GetAllFamiliasQuery : IRequest<BaseResponse<IEnumerable<GetAllFamiliaResponseDto>>>
    {
    }
}