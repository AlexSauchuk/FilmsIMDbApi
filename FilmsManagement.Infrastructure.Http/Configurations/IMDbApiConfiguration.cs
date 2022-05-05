using FilmsManagement.Infrastructure.Core.Configurations;
using Microsoft.Extensions.Configuration;

namespace FilmsManagement.Infrastructure.Http.Configurations
{
    public class IMDbApiConfiguration : IIMDbApiConfiguration
    {
        private const string ConfigurationKey = "IMDbApiConfiguration";

        public IMDbApiConfiguration(IConfiguration configuration)
        {
            configuration
                .GetSection(ConfigurationKey)
                .Bind(this);
        }

        public string Url { get; set; }

        public string ApiKey { get; set; }
    }
}
