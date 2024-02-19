namespace StockLink.Compra.Domain.Entities
{
    public class Pedido
    {
        public int? Id { get; set; }
        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public int Cantidad { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaPedido { get; set; }
        public int EstadoPedido { get; set; }
    }
}