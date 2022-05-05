using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using FilmsManagement.Infrastructure.Core.Http;

namespace FilmsManagement.Infrastructure.Http.Base
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private static readonly ConcurrentDictionary<string, Lazy<IHttpClientWrapper>> ClientList
       = new ConcurrentDictionary<string, Lazy<IHttpClientWrapper>>(StringComparer.OrdinalIgnoreCase);

        private static readonly Lazy<IHttpClientWrapper> DefaultClient =
            new Lazy<IHttpClientWrapper>(() => CreateNetHttpClient(), LazyThreadSafetyMode.ExecutionAndPublication);

        private const string DefaultKey = "Default";

        public IHttpClient Create()
        {
            return Create(DefaultKey);
        }

        public IHttpClient Create(string name)
        {
            if (name.Equals(DefaultKey, StringComparison.OrdinalIgnoreCase)) return DefaultClient.Value;

            var lazyValue = ClientList.GetOrAdd(name,
                n => new Lazy<IHttpClientWrapper>(() => CreateNetHttpClient(), LazyThreadSafetyMode.ExecutionAndPublication));

            return lazyValue.Value;
        }

        private void Clear()
        {
            ClientList.Clear();
        }

        private static IHttpClientWrapper CreateNetHttpClient()
        {
            var httpClient = new HttpClient();

            return new HttpClientWrapper(httpClient);
        }
    }
}
