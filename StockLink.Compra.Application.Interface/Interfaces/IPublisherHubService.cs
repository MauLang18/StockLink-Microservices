namespace StockLink.Compra.Application.Interface.Interfaces
{
    public interface IPublisherHubService
    {
        Task SendNotification(int Id, string CodigoCliente, string Cliente, string CodigoArticulo, string Articulo, string Vendedor, int Cantidad, int EstadoPedido, DateTime FechaPedido, string Observacion);
    }
}