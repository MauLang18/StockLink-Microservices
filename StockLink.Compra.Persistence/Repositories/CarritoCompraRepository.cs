using Dapper;
using StockLink.Compra.Application.Dtos.CarritoCompra.Response;
using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Persistence.Context;
using System.Data;

namespace StockLink.Compra.Persistence.Repositories
{
    public class CarritoCompraRepository : ICarritoCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CarritoCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllCarritoCompraResponseDto>> GetAllCarritoByVendedor(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);

            var carritoCompra = await connection.QueryAsync<GetAllCarritoCompraResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return carritoCompra!;
        }
    }
}