namespace StockLink.Compra.Domain.Entities
{
    public class CarritoCompra
    {
        public int? Id { get; set; }
        public string? CodigoArticulo { get; set; }
        public string? DescripcionArticulo { get; set; }
        public string? Vendedor { get; set; }
        public int Cantidad { get; set; }
    }
}