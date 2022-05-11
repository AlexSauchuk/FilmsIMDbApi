using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Core.Http;
using FilmsManagement.Infrastructure.Core.Repositories;
using FilmsManagement.Infrastructure.Core.Configurations;
using FilmsManagement.Infrastructure.Core.Exceptions;
using FilmsManagement.Infrastructure.Http.DataModels;
using FilmsManagement.Infrastructure.Http.Mappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmsManagement.Infrastructure.Http.Repositories
{
    public class IMDbRepository : IFilmsSearchRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIMDbApiConfiguration _configuration;

        public IMDbRepository(IHttpClientFactory httpClientFactory, IIMDbApiConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<IBaseMovie>> SearchByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await SearchAsync(title, "Search", cancellationToken);
        }

        public async Task<IReadOnlyList<IBaseMovie>> SearchFilmsByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await SearchAsync(title, "SearchMovie", cancellationToken);
        }

        public async Task<IReadOnlyList<IBaseMovie>> SearchSeriesByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await SearchAsync(title, "SearchSeries", cancellationToken);
        }

        public async Task<IMovie> GetFilmByIdAsync(string id, CancellationToken cancellationToken)
        {
            var searchFilmUrl = $"{_configuration.Url}/Title/{_configuration.ApiKey}/{id}";

            var result = await SendSearchRequest<FilmDataModel>(searchFilmUrl, HttpMethod.Get, cancellationToken);

            return result.ToDomainModel();
        }

        public async Task<MovieWikipedia> GetFilmWikipedia(string id, CancellationToken cancellationToken)
        {
            var searchFilmUrl = $"{_configuration.Url}/Wikipedia/{_configuration.ApiKey}/{id}";

            var result = await SendSearchRequest<MovieWikipediaDataModel>(searchFilmUrl, HttpMethod.Get, cancellationToken);

            return result.ToDomainModel();
        }

        public async Task<MoviePoster> GetFilmPoster(string id, CancellationToken cancellationToken)
        {
            var searchFilmUrl = $"{_configuration.Url}/Posters/{_configuration.ApiKey}/{id}";

            var result = await SendSearchRequest<MoviePosterDataModel>(searchFilmUrl, HttpMethod.Get, cancellationToken);

            return result.ToDomainModel();
        }

        private async Task<IReadOnlyList<IBaseMovie>> SearchAsync(string searchQuery, string searchType, CancellationToken cancellationToken)
        {
            var searchFilmUrl = $"{_configuration.Url}/{searchType}/{_configuration.ApiKey}/{searchQuery}";

            var searchResult = await SendSearchRequest<SearchResultDataModel>(searchFilmUrl, HttpMethod.Get, cancellationToken);

            return searchResult.Results.ToDomainModel()?.ToList();
        }

        private async Task<T> SendSearchRequest<T>(string url, HttpMethod method, CancellationToken cancellationToken)
        {
            string content = null;

            using (var httpRequestMessage = new HttpRequestMessage(method, url))
            {
                try
                {
                    IHttpClient client = _httpClientFactory.Create();

                    using (var result = await client.SendAsync(httpRequestMessage, cancellationToken))
                    {
                        if (result.StatusCode != HttpStatusCode.OK)
                        {
                            throw new FilmsSearchRequestException($"An error occured during search request: {result.StatusCode}");
                        }

                        content = await result.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new FilmsSearchRequestException("Can't access the IMDb api", ex);
                }
            }

            if (content != null)
            {
                var title = JObject.Parse(content).Value<string>("title");
                var searchType = JObject.Parse(content).Value<string>("searchType");
                if (string.IsNullOrEmpty(searchType) && string.IsNullOrEmpty(title))
                    throw new MovieNotFoundException("IMDb doesn't contain movie with such id");
            }

            return content != null  ? JsonConvert.DeserializeObject<T>(content) : default;
        }
    }
}
