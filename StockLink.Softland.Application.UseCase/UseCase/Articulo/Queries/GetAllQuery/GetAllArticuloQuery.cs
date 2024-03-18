using MediatR;
using StockLink.Softland.Application.Dto.Articulo.Response;
using StockLink.Softland.Application.UseCase.Commons.Bases;

namespace StockLink.Softland.Application.UseCase.UseCase.Articulo.Queries.GetAllQuery
{
    public class GetAllArticuloQuery : IRequest<BaseResponse<IEnumerable<GetAllArticuloResponseDto>>>
    {
        public string? DESC { get; set; }
        public string? PRIV { get; set; }
        public string? ORDER { get; set; }
        public int DRAINSA { get; set; }
        public int MOTORNOVA { get; set; }
    }
}