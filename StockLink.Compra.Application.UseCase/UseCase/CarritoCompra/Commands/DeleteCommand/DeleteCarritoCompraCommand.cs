using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.DeleteCommand
{
    public class DeleteCarritoCompraCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}