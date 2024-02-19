using StockLink.Compra.Application.Interface.Interfaces;
using StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<CarritoCompra> CarritoCompra { get; }
        public IGenericRepository<Pedido> Pedido { get; }

        public UnitOfWork(IGenericRepository<CarritoCompra> carritoCompra, IGenericRepository<Pedido> pedido)
        {
            CarritoCompra = carritoCompra;
            Pedido = pedido;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}