using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace JDPodrozeAPI.Services
{
    public class EmailsService : IEmailsService
    {
        private readonly IConfiguration _configuration;

        public EmailsService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public void SendEmail(string email, string senderDetails, string subject, string body, bool includeLogo = true)
        {
            MailAddress fromAddress = new MailAddress(_configuration["SMTP:Email"]!, "JD Podróże");
            MailAddress toAddress = new MailAddress(email, senderDetails);

            using (SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential() { UserName = fromAddress.Address, Password = _configuration["SMTP:Password"] }
            })
            {
                using (MailMessage message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    if (includeLogo)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "logo.png");
                        Attachment attachment = new Attachment(filePath);
                        attachment.ContentId = "logo";
                        attachment.ContentDisposition.Inline = true;
                        attachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                        message.Attachments.Add(attachment);
                    }
                    smtpClient.Send(message);
                }
            }
        }
    }
}