namespace StockLink.Softland.Application.Dto.Articulo.Response
{
    public class GetAllArticuloResponseDto
    {
        public string? Codigo { get; set; }
        public string? CodigoProveedor { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public decimal? CantidadBodega1 { get; set; }
        public decimal? CantidadBodega2 { get; set; }
    }
}