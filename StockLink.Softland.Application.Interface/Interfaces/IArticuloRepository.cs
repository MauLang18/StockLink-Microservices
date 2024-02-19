using StockLink.Softland.Application.Dto.Articulo.Response;

namespace StockLink.Softland.Application.Interface.Interfaces
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<GetAllArticuloResponseDto>> GetAllArticulos(string storedProcedure, object parameter);
    }
}