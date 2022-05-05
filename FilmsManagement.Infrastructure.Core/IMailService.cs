using FilmsManagement.Domain.Requests;
using System.Threading.Tasks;

namespace FilmsManagement.Infrastructure.Core
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
