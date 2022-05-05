using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Requests;
using FilmsManagement.Infrastructure.Core;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;

namespace FilmsManagement.Utility
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, CancellationToken cancellationToken)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mailRequest.Body };

            using(var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls, cancellationToken);
                await smtp.AuthenticateAsync(_mailSettings.SmtpUser, _mailSettings.SmtpPassword, cancellationToken);
                await smtp.SendAsync(email, cancellationToken);
                await smtp.DisconnectAsync(true, cancellationToken);
            }
        }
    }
}
