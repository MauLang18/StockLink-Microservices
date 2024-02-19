namespace StockLink.Cotizacion.Domain.Entities
{
    public partial class Cotizaciones : BaseEntity
    {
        public Cotizaciones()
        {
            DetalleCotizacions = new HashSet<DetalleCotizacion>();
        }

        public string? CodigoCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Vendedor { get; set; }
        public decimal Descuento { get; set; }

        public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; }
    }
}