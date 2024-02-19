using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.UpdateCommand
{
    public class UpdateCarritoCompraCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
    }
}