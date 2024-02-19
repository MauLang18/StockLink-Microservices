namespace StockLink.Cotizacion.Application.Dtos.DetalleCotizacion.Response
{
    public class ReportCotizacionResponseDto
    {
        public int Id { get; set; }
        public int IdCotizacion { get; set; }
        public string? Tipo { get; set; }

        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public decimal Descuento { get; set; }

        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}