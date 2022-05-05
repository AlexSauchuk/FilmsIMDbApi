using FilmsManagement.Domain.Models;

namespace FilmsManagement.Domain
{
    public class UserNotificationResponse
    {
        public bool NotifyUser { get; set; }

        public IMovie SuggestedMovie { get; set; }
    }
}
