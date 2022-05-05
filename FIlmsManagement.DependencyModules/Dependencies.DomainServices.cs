using FilmsManagement.DomainServices;
using FilmsManagement.DomainServices.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.DependencyModules
{
    public static partial class Dependencies
    {
        public static IServiceCollection RegisterMovieSearchDomainService(this IServiceCollection services)
        {
            services.AddTransient<IMovieSearchDomainService, MovieSearchDomainService>();

            return services
                .RegisterFilmsSearchRepository();
        }

        public static IServiceCollection RegisterUserWatchListDomainService(this IServiceCollection services)
        {
            services.AddTransient<IUserWatchListDomainService, UserWatchListDomainService>();

            return services
                .RegisterUserDomainService()
                .RegisterUserWatchListRepository();
        }

        public static IServiceCollection RegisterMovieDomainService(this IServiceCollection services)
        {
            services.AddTransient<IMovieDomainService, MovieDomainService>();

            return services
                .RegisterFilmsSearchRepository();
        }

        public static IServiceCollection RegisterUserDomainService(this IServiceCollection services)
        {
            services.AddTransient<IUserDomainService, UserDomainService>();

            return services
                .RegisterUserRepository();
        }
    }
}
