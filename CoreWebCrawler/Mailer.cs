using System.Net;
using System.Net.Mail;

namespace CoreWebCrawler
{
    public class Mailer
    {
        public static void SendMail()
        {
            var fromAddress = new MailAddress(MailerConfigurator.GetSenderAddress(), MailerConfigurator.GetSenderName());
            var toAddress = new MailAddress(MailerConfigurator.GetRecipientAddress(), MailerConfigurator.GetRecipientName());
            const string subject = "Trinkets List";

            SmtpClient smtp = new SmtpClient
            {
                Host = MailerConfigurator.GetSenderServer(),
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, MailerConfigurator.GetSenderPassword()),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = MailerBodyBuilder.BuildBody()
            })
            {
                smtp.Send(message);
            }
        }
    }
}
