namespace StockLink.Cotizacion.Domain.Entities
{
    public partial class DetalleCotizacion : BaseEntity
    {
        public string? CodigoArticulo { get; set; }
        public string? Articulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdCotizacion { get; set; }

        public virtual Cotizaciones CotizacionNavigation { get; set; } = null!;
    }
}