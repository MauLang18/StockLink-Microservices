namespace StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response
{
    public class DetalleCotizacionResponseDto
    {
        public int Id { get; set; }
        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdCotizacion { get; set; }
    }
}