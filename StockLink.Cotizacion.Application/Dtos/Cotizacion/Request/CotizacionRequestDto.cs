namespace StockLink.Cotizacion.Application.Dtos.Cotizacion.Request
{
    public class CotizacionRequestDto
    {
        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public decimal Descuento { get; set; }
    }
}