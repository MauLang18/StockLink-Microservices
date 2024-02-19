namespace StockLink.Cotizacion.Application.Dtos.Cotizacion.Response
{
    public class CotizacionResponseDto
    {
        public int Id { get; set; }
        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public decimal Descuento { get; set; }
    }
}