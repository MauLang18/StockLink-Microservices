using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.DeleteByVendedorCommand
{
    public class DeleteCarritoCompraByVendedorCommand : IRequest<BaseResponse<bool>>
    {
        public string? Vendedor { get; set; }
    }
}