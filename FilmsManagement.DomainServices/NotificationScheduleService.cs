using System;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.DomainServices.Core;
using Microsoft.Extensions.Hosting;

namespace FilmsManagement.DomainServices
{
    public class NotificationScheduleService : IHostedService
    {
        private readonly INotificationDomainService _notificationDomainService;
        private Timer _timer;

        public NotificationScheduleService(INotificationDomainService notificationDomainService)
        {
            _notificationDomainService = notificationDomainService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TimeSpan interval = TimeSpan.FromDays(7);

            var today = DateTime.Today;
            var daysUntilSunday = ((int) DayOfWeek.Sunday - (int) today.DayOfWeek + 7) % 7;
            var nextRunTime = today.AddDays(daysUntilSunday).AddHours(19).AddMinutes(30);

            var currentTime = DateTime.Now;
            var firstInterval = nextRunTime.Subtract(currentTime);

            Action action = () =>
            {
                var timeout = Task.Delay(firstInterval);
                timeout.Wait();

                SendNotifications(cancellationToken);

                _timer = new Timer(SendNotifications, cancellationToken, TimeSpan.Zero, interval);
            };

            Task.Run(action, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void SendNotifications(object state)
        {
            var cancellationToken = (CancellationToken) state;

            _notificationDomainService.SendUserNotificationAsync("alexandrsavchuk.97@gmail.com", cancellationToken);
        }
    }
}
