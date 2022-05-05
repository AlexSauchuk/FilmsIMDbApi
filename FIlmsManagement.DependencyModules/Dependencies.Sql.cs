using FilmsManagement.Infrastructure.Core.Repositories;
using FilmsManagement.Infrastructure.MSSql;
using FilmsManagement.Infrastructure.Sql.Contexts;
using FilmsManagement.Infrastructure.Sql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.DependencyModules
{
    public static partial class Dependencies
    {
        public static IServiceCollection RegisterUserWatchListRepository(this IServiceCollection services)
        {
            services.RegisterSqlRepository<IUserWatchListRepository, UserWatchListRepository, FilmsManagementContext>();
            return services;
        }

        public static IServiceCollection RegisterUserRepository(this IServiceCollection services)
        {
            services.RegisterSqlRepository<IUserRepository, UserRepository, FilmsManagementContext>();
            return services;
        }

        private static IServiceCollection RegisterSqlRepository<TRepositoryFrom, TRepositoryTo, TContext>(this IServiceCollection services)
            where TRepositoryTo : BaseSqlRepository<TContext>, TRepositoryFrom
            where TRepositoryFrom : class
            where TContext: BaseSqlContext
        {
            SqlDependencyModule.LoadSqlRepository<TRepositoryFrom, TRepositoryTo, TContext>(services);

            services.AddTransient<TContext, TContext>();

            return services;
        }
    }
}
