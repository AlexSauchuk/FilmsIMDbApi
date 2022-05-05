namespace FilmsManagement.Infrastructure.Core.Configurations
{
    public interface ISqlConnectionStringProvider
    {
        string GetConnectionString(string connectionStringName);
    }
}
