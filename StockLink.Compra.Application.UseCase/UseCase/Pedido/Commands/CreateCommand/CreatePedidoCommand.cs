using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.CreateCommand
{
    public class CreatePedidoCommand : IRequest<BaseResponse<bool>>
    {
        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public int Cantidad { get; set; }
        public string? Observacion { get; set; }
        public string? Despacho { get; set; }
        public int EstadoPedido { get; set; }
    }
}