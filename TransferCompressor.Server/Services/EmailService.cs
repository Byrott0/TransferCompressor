using System.Net;
using System.Net.Mail;

namespace TransferCompressor.Server.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailService(IConfiguration configuration)
        {
            // Haal waarden op uit appsettings.json
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUser = configuration["EmailSettings:SmtpUser"];
            _smtpPass = configuration["EmailSettings:SmtpPass"];
            _senderEmail = configuration["EmailSettings:SenderEmail"];
            _senderName = configuration["EmailSettings:SenderName"];
        }
        
        public async Task SendEmailAsync(string naarGebruiker, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                EnableSsl = true // Gebruik SSL/TLS voor een veilige verbinding
            })
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail, _senderName), // Gebruik herkenbare afzender
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Zet op true als je HTML-e-mails verstuurt
                };
                mailMessage.To.Add(naarGebruiker);

                await client.SendMailAsync(mailMessage); // Asynchroon versturen van de e-mail
            }
        }
    }
}