using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsManagement.Infrastructure.Core.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, HttpCompletionOption option, CancellationToken cancelToken);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage message);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, HttpCompletionOption option);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancelToken);
    }
}
