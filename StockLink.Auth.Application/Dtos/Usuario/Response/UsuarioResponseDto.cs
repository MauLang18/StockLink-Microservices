namespace StockLink.Auth.Application.Dtos.Usuario.Response
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public string? Rol { get; set; }
    }
}