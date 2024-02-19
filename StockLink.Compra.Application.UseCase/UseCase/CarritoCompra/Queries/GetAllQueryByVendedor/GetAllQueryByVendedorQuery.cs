using MediatR;
using StockLink.Compra.Application.Dtos.CarritoCompra.Response;
using StockLink.Compra.Application.UseCase.Commons.Bases;

namespace StockLink.Compra.Application.UseCase.UseCase.CarritoCompra.Queries.GetAllQueryByVendedor
{
    public class GetAllQueryByVendedorQuery : IRequest<BaseResponse<IEnumerable<GetAllCarritoCompraResponseDto>>>
    {
        public string? Vendedor { get; set; }
    }
}