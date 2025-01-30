namespace TransferCompressor.Server.Services
{
    public interface IEmailService
    {
        void SendEmailWithAttachment(string naarGebruiker, string subject, string body, byte[] attachmentData, string attachmentName);

        Task SendEmailWithImage(string naarGebruiker, string subject, string body, byte[] attachmentData);
        void SendEmail(string naarGebruiker, string subject, string body);

        Task SendEmailAsync(string naarGebruiker, string subject, string body);
    }
}
