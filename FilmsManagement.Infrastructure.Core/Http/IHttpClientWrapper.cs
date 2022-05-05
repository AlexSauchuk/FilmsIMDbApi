using System;

namespace FilmsManagement.Infrastructure.Core.Http
{
    public interface IHttpClientWrapper : IHttpClient, IDisposable
    {
    }
}
