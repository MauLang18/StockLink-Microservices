namespace StockLink.Softland.Domain.Entities
{
    public class Familias
    {
        public string? CLASIFICACION { get; set; }
        public string? DESCRIPCION { get; set; }
        public string? AGRUPACION { get; set; }
        public string? USA_NUMEROS_SERIE { get; set; }
        public string? PLANTILLA_SERIE { get; set; }
        public string? APORTE_CODIGO { get; set; }
        public string? TIPO_CODIGO_BARRAS { get; set; }
        public string? UNIDAD_MEDIDA { get; set; }
        public byte? NoteExistsFlag { get; set; }
        public DateTime? RecordDate { get; set; }
        public Guid? RowPointer { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}