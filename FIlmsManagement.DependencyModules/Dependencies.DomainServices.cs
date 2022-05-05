using FilmsManagement.DomainServices;
using FilmsManagement.DomainServices.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.DependencyModules
{
    public static partial class Dependencies
    {
        public static IServiceCollection RegisterMovieDomainService(this IServiceCollection services)
        {
            services.AddTransient<IMovieDomainService, MovieDomainService>();

            return services
                .RegisterFilmsSearchRepository();
        }

        public static IServiceCollection RegisterMovieSearchDomainService(this IServiceCollection services)
        {
            services.AddTransient<IMovieSearchDomainService, MovieSearchDomainService>();

            return services
                .RegisterMovieRepository()
                .RegisterFilmsSearchRepository();
        }

        public static IServiceCollection RegisterNotificationDomainService(this IServiceCollection services)
        {
            services.AddTransient<INotificationDomainService, NotificationDomainService>();

            return services
                .RegisterMovieSearchDomainService()
                .RegisterUserDomainService()
                .RegisterUserWatchListDomainService();
        }

        public static IServiceCollection RegisterUserDomainService(this IServiceCollection services)
        {
            services.AddTransient<IUserDomainService, UserDomainService>();

            return services
                .RegisterUserRepository();
        }

        public static IServiceCollection RegisterUserWatchListDomainService(this IServiceCollection services)
        {
            services.AddTransient<IUserWatchListDomainService, UserWatchListDomainService>();

            return services
                .RegisterUserDomainService()
                .RegisterUserWatchListRepository();
        }
    }
}
