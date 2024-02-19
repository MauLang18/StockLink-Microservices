using Dapper;
using StockLink.Softland.Application.Dto.Cliente.Response;
using StockLink.Softland.Application.Interface.Interfaces;
using StockLink.Softland.Persistence.Context;
using System.Data;

namespace StockLink.Softland.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllClienteResponseDto>> GetAllClientes(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var clientes = await connection.QueryAsync<GetAllClienteResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return clientes;
        }
    }
}