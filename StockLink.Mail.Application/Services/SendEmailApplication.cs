using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using StockLink.Mail.Application.Dtos.Mail.Request;
using StockLink.Mail.Application.Interfaces;
using MailKit.Net.Smtp;

namespace StockLink.Mail.Application.Services
{
    public class SendEmailApplication : ISendEmailApplication
    {
        private readonly IConfiguration _configuration;

        public SendEmailApplication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(MailRequestDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.Para));
            email.Cc.Add(MailboxAddress.Parse(request.Cc));
            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls);

            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value,
                _configuration.GetSection("Email:PassWord").Value);

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}