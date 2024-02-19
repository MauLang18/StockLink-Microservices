using StockLink.Softland.Application.Dto.Cliente.Response;

namespace StockLink.Softland.Application.Interface.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<GetAllClienteResponseDto>> GetAllClientes(string storedProcedure, object parameter);
    }
}