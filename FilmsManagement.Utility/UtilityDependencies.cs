using FilmsManagement.Infrastructure.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.Utility
{
    public static class UtilityDependencies
    {
        public static IServiceCollection RegisterUtilities(this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
