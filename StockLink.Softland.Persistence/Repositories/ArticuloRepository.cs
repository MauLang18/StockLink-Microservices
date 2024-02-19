using Dapper;
using StockLink.Softland.Application.Dto.Articulo.Response;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Persistence.Context;
using System.Data;

namespace StockLink.Softland.Persistence.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllArticuloResponseDto>> GetAllArticulos(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var articulos = await connection.QueryAsync<GetAllArticuloResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return articulos;
        }
    }
}