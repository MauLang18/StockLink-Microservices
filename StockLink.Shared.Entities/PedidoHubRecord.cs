namespace StockLink.Shared.Entities
{
    public record PedidoHubRecord(int Id, string CodigoCliente, string Cliente, string CodigoArticulo, string Articulo, string Vendedor, int Cantidad, int EstadoPedido, DateTime FechaPedido, string Observacion);
}