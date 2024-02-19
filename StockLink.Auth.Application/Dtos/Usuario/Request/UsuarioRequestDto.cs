namespace StockLink.Auth.Application.Dtos.Usuario.Request
{
    public class UsuarioRequestDto
    {
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public int? Rol { get; set; }
    }
}