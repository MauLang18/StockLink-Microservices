using StockLink.Compra.Domain.Entities;

namespace StockLink.Compra.Application.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CarritoCompra> CarritoCompra { get; }
        IGenericRepository<Pedido> Pedido { get; }
    }
}