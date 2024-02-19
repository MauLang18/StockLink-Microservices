namespace StockLink.Softland.Domain.Entities
{
    public class ExistenciaBodega
    {
        public string? ARTICULO { get; set; }
        public string? BODEGA { get; set; }
        public decimal? EXISTENCIA_MINIMA { get; set; }
        public decimal? EXISTENCIA_MAXIMA { get; set; }
        public decimal? PUNTO_DE_REORDEN { get; set; }
        public decimal? CANT_DISPONIBLE { get; set; }
        public decimal? CANT_RESERVADA { get; set; }
        public decimal? CANT_NO_APROBADA { get; set; }
        public decimal? CANT_VENCIDA { get; set; }
        public decimal? CANT_TRANSITO { get; set; }
        public decimal? CANT_PRODUCCION { get; set; }
        public decimal? CANT_PEDIDA { get; set; }
        public decimal? CANT_REMITIDA { get; set; }
        public string? CONGELADO { get; set; }
        public DateTime? FECHA_CONG { get; set; }
        public string? BLOQUEA_TRANS { get; set; }
        public DateTime? FECHA_DESCONG { get; set; }
        public decimal? COSTO_UNT_PROMEDIO_LOC { get; set; }
        public decimal? COSTO_UNT_PROMEDIO_DOL { get; set; }
        public decimal? COSTO_UNT_ESTANDAR_LOC { get; set; }
        public decimal? COSTO_UNT_ESTANDAR_DOL { get; set; }
        public decimal? COSTO_PROM_COMPARATIVO_LOC { get; set; }
        public decimal? COSTO_PROM_COMPARATIVO_DOLAR { get; set; }
        public byte? NoteExistsFlag { get; set; }
        public DateTime? RecordDate { get; set; }
        public Guid? RowPointer { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}