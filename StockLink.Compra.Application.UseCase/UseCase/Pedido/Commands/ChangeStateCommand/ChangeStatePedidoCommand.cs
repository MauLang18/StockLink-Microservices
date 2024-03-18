using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.Pedido.Commands.ChangeStateCommand
{
    public class ChangeStatePedidoCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int EstadoPedido { get; set; }
        public string? Despacho { get; set; }
    }
}