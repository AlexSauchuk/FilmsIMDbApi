using System;
using FilmsManagement.Infrastructure.Core.Configurations;
using FilmsManagement.Infrastructure.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmsManagement.Infrastructure.MSSql
{
    public abstract class BaseSqlContext : DbContext
    {
        private readonly ISqlConnectionStringProvider _connectionStringProvider;

        protected BaseSqlContext(ISqlConnectionStringProvider sqlConnectionStringProvider)
        {
            _connectionStringProvider = sqlConnectionStringProvider ?? throw new ArgumentException("sqlConnectionStringProvider");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _connectionStringProvider.GetConnectionString(GetType().Name) 
                ?? throw new FilmsManagementApplicationConfigurationException($"Unable to find connection string: {GetType().Name}");

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }
    }
}
