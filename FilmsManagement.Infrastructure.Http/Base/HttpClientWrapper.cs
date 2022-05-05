using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Infrastructure.Core.Http;

namespace FilmsManagement.Infrastructure.Http.Base
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;
        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, HttpCompletionOption option, CancellationToken cancelToken)
        {
            return _client.SendAsync(message, option, cancelToken);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message)
        {
            return _client.SendAsync(message);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, HttpCompletionOption option)
        {
            return _client.SendAsync(message, option);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancelToken)
        {
            return _client.SendAsync(message, cancelToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client?.Dispose();
            }
        }
    }
}
