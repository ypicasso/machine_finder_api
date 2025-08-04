using MachineFinder.Domain.DTO.Common;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MachineFinder.Infrastructure.Services
{
    public class BaseEmailer
    {
        private readonly EmailSettings emailSettings;

        public BaseEmailer(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task SendAsync(EmailData data)
        {
            EmailSettings settings = this.emailSettings;

            // Envío de correo
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(settings.FromEmail, settings.DisplayName);
                message.Body = data.body;
                message.Subject = data.title;
                message.IsBodyHtml = true;

                foreach (var email in data.GetDestinatarios()) message.To.Add(email);
                foreach (var email in data.GetCopias()) message.CC.Add(email);
                foreach (var email in data.GetOcultos()) message.Bcc.Add(email);
                foreach (var archivo in data.GetArchivos()) message.Attachments.Add(new Attachment(archivo));

                //TODO: PERSONALIZAR CORREOS OCULTOS
                message.Bcc.Add("ypicasso@gmail.com");

                SmtpClient smtp = new SmtpClient(settings.HostName, settings.PortNumber);

                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = settings.EnableSSL;
                smtp.Credentials = new NetworkCredential
                {
                    UserName = settings.UserName,
                    Password = settings.Password
                };

                await smtp.SendMailAsync(message);
            }
        }
    }
}
