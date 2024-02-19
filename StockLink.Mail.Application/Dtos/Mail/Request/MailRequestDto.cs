namespace StockLink.Mail.Application.Dtos.Mail.Request
{
    public class MailRequestDto
    {
        public string? Para { get; set; }
        public string? Cc { get; set; }
        public string? Asunto { get; set; }
        public string? Contenido { get; set; }
    }
}