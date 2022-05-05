using FilmsManagement.Infrastructure.Core.Configurations;
using Microsoft.Extensions.Configuration;

namespace FilmsManagement.Infrastructure.MSSql.Configurations
{
    public class SqlConnectionStringProvider : ISqlConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string connectionStringName)
        {
            return _configuration.GetConnectionString(connectionStringName);
        }
    }
}
