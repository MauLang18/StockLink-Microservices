using StockLink.Compra.Application.Dtos.Pedido.Response;

namespace StockLink.Compra.Application.Interface.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<GetAllPedidoResponseDto>> GetAllPedidos(string storedProcedure, object parameter);
        Task<IEnumerable<GetAllPedidoResponseDto>> GetAllPedidosEnviado(string storedProcedure, object parameter);
    }
}