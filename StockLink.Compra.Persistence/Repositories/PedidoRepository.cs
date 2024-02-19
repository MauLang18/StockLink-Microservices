using Dapper;
using StockLink.Compra.Application.Dtos.Pedido.Response;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Persistence.Context;
using System.Data;

namespace StockLink.Compra.Persistence.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPedidoResponseDto>> GetAllPedidos(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var pedidos = await connection.QueryAsync<GetAllPedidoResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return pedidos!;
        }

        public async Task<IEnumerable<GetAllPedidoResponseDto>> GetAllPedidosEnviado(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var pedidos = await connection.QueryAsync<GetAllPedidoResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return pedidos!;
        }
    }
}