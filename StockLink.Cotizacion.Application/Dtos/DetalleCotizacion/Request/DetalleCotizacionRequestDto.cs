namespace StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Request
{
    public class DetalleCotizacionRequestDto
    {
        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdCotizacion { get; set; }
    }
}