using FilmsManagement.Infrastructure.Core.Configurations;
using FilmsManagement.Infrastructure.MSSql.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.Infrastructure.MSSql
{
    public static class SqlDependencyModule
    {
        public static void LoadSqlRepository<TFrom, TTo, TContext>(IServiceCollection services)
            where TFrom : class
            where TTo : BaseSqlRepository<TContext>, TFrom
            where TContext : BaseSqlContext
        {
            services.AddSingleton<ISqlConnectionStringProvider, SqlConnectionStringProvider>();
            services.AddTransient<TFrom, TTo>();
        }
    }
}
