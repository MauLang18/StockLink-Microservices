using MediatR;
using StockLink.Compra.Application.Dtos.Pedido.Response;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Queries.GetAllQueryEnviado
{
    public class GetAllQueryEnviadoQuery : IRequest<BaseResponse<IEnumerable<GetAllPedidoResponseDto>>>
    {
        public string? CodigoCliente { get; set; }
        public string? Vendedor { get; set; }
        public DateTime? FechaPedido { get; set; }
    }
}