namespace FilmsManagement.Infrastructure.Core.Http
{
    public interface IHttpClientFactory
    {
        IHttpClient Create();
    }
}
