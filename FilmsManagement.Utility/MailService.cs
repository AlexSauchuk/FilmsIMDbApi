using System.Threading.Tasks;
using FilmsManagement.Domain.Requests;
using FilmsManagement.Infrastructure.Core;
using Microsoft.Extensions.Options;

namespace FilmsManagement.Utility
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public Task SendEmailAsync(MailRequest mailRequest)
        {
            return Task.CompletedTask;
        }
    }
}
