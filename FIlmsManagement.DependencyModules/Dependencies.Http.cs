using FilmsManagement.Infrastructure.Core.Configurations;
using FilmsManagement.Infrastructure.Core.Http;
using FilmsManagement.Infrastructure.Core.Repositories;
using FilmsManagement.Infrastructure.Http.Base;
using FilmsManagement.Infrastructure.Http.Configurations;
using FilmsManagement.Infrastructure.Http.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.DependencyModules
{
    public static partial class Dependencies
    {
        public static IServiceCollection RegisterFilmsSearchRepository(this IServiceCollection services)
        {
            services.AddTransient<IFilmsSearchRepository, IMDbRepository>();

            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            return services
                .RegisterIMDbApiConfiguration();
        }

        private static IServiceCollection RegisterIMDbApiConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IIMDbApiConfiguration, IMDbApiConfiguration>();

            return services;
        }
    }
}
