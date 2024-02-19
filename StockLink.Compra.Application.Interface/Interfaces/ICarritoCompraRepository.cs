using StockLink.Compra.Application.Dtos.CarritoCompra.Response;

namespace StockLink.Compra.Application.Interface.Interfaces
{
    public interface ICarritoCompraRepository
    {
        Task<IEnumerable<GetAllCarritoCompraResponseDto>> GetAllCarritoByVendedor(string storedProcedure, object parameter);
    }
}