using MediatR;
using StockLink.Compra.Application.Dtos.Pedido.Response;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Queries.GetAllQuery
{
    public class GetAllPedidoQuery : IRequest<BaseResponse<IEnumerable<GetAllPedidoResponseDto>>>
    {
        public string? Despacho { get; set; }
    }
}