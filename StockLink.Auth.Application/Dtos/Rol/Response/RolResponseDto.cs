namespace StockLink.Auth.Application.Dtos.Rol.Response
{
    public class RolResponseDto
    {
        public int Id { get; set; }
        public string? Rol { get; set; }
        public string? Privilegios { get; set; }
        public int Drainsa { get; set; }
        public int Motornova { get; set; }
        public string? EstadoDrainsa { get; set; }
        public string? EstadoMotornova { get; set; }
    }
}