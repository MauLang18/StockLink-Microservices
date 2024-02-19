namespace StockLink.Softland.Domain.Entities
{
    public class ArticuloPrecio
    {
        public string? NIVEL_PRECIO { get; set; }
        public string? MONEDA { get; set; }
        public int? VERSION { get; set; }
        public string? ARTICULO { get; set; }
        public int? VERSION_ARTICULO { get; set; }
        public decimal? PRECIO { get; set; }
        public string? ESQUEMA_TRABAJO { get; set; }
        public decimal? MARGEN_MULR { get; set; }
        public decimal? MARGEN_UTILIDAD { get; set; }
        public DateTime? FECHA_INICIO { get; set; }
        public DateTime? FECHA_FIN { get; set; }
        public DateTime? FECHA_ULT_MODIF { get; set; }
        public string? USUARIO_ULT_MODIF { get; set; }
        public decimal? MARGEN_UTILIDAD_MIN { get; set; }
        public byte? NoteExistsFlag { get; set; }
        public DateTime? RecordDate { get; set; }
        public Guid? RowPointer { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}