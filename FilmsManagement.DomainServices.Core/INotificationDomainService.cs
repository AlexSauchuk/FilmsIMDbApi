using System.Threading;
using System.Threading.Tasks;

namespace FilmsManagement.DomainServices.Core
{
    public interface INotificationDomainService
    {
        Task SendUserNotificationAsync(string userMail, CancellationToken cancellationToken);
    }
}
