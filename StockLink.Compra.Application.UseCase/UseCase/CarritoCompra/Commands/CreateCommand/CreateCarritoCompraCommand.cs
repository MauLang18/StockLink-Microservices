using MediatR;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Commands.CreateCommand
{
    public class CreateCarritoCompraCommand : IRequest<BaseResponse<bool>>
    {
        public string? CodigoArticulo { get; set; }
        public string? DescripcionArticulo { get; set; }
        public string? Vendedor { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}