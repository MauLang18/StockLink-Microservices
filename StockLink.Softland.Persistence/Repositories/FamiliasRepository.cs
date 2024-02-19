using Dapper;
using StockLink.Softland.Application.Dto.Familia.Response;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Persistence.Context;
using System.Data;

namespace StockLink.Softland.Persistence.Repositories
{
    public class FamiliasRepository : IFamiliasRepository
    {
        private readonly ApplicationDbContext _context;

        public FamiliasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllFamiliaResponseDto>> GetAllFamilias(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var familias = await connection.QueryAsync<GetAllFamiliaResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return familias;
        }
    }
}