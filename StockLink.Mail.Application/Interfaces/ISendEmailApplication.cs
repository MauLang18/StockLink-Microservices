using StockLink.Mail.Application.Dtos.Mail.Request;

namespace StockLink.Mail.Application.Interfaces
{
    public interface ISendEmailApplication
    {
        void SendEmail(MailRequestDto request);
    }
}