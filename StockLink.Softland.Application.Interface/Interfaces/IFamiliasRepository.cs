using StockLink.Softland.Application.Dto.Familia.Response;

namespace StockLink.Softland.Application.Interface.Interfaces
{
    public interface IFamiliasRepository
    {
        Task<IEnumerable<GetAllFamiliaResponseDto>> GetAllFamilias(string storedProcedure, object parameter);
    }
}