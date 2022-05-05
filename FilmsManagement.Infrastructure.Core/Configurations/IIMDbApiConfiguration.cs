namespace FilmsManagement.Infrastructure.Core.Configurations
{
    public interface IIMDbApiConfiguration
    {
        string Url { get; set; }

        string ApiKey { get; set; }
    }
}
