namespace StockLink.Auth.Application.Dtos.Usuario.Response
{
    public class UsuarioByIdResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public int? Rol { get; set; }
        public string? Despacho { get; set; }
    }
}