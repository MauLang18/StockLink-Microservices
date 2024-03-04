using MediatR;
using StockLink.Softland.Application.Dto.Articulo.Response;
using StockLink.Softland.Application.UseCase.Commons.Bases;

namespace StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQueryFamilia
{
    public class GetAllArticuloFamiliaQuery : IRequest<BaseResponse<IEnumerable<GetAllArticuloResponseDto>>>
    {
        public string? DESC { get; set; }
        public string? PRIV { get; set; }
        public string? ORDER { get; set; }
    }
}