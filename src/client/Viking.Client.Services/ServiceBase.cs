using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Viking.Client.Services
{
    public abstract class ServiceBase
    {
        protected HttpClient Client { get; }
        private readonly JsonSerializerOptions serializerOptions;

        public ServiceBase(HttpClient client)
        {
            Client = client;

            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        protected async Task ExecuteAsync<T>(string? requestUri, T value, CancellationToken cancellationToken = default)
        {
            await Client.PostAsJsonAsync(requestUri, value, serializerOptions, cancellationToken);
        }

        protected async Task<TResponse> ExecuteAsync<T, TResponse>(string? requestUri, T value, CancellationToken cancellationToken = default)
        {
            var response = await Client.PostAsJsonAsync(requestUri, value, serializerOptions, cancellationToken);
            return await HandleResponseAsync<TResponse>(response, cancellationToken);
        }

        protected async Task UpdateAsync<T>(string? requestUri, T value, CancellationToken cancellationToken = default)
        {
            await Client.PutAsJsonAsync(requestUri, value, serializerOptions, cancellationToken);
        }

        protected async Task<TResponse> UpdateAsync<T, TResponse>(string requestUri, T value, CancellationToken cancellationToken = default)
        {
            var response = await Client.PutAsJsonAsync(requestUri, value, serializerOptions, cancellationToken);
            return await HandleResponseAsync<TResponse>(response, cancellationToken);
        }

        protected Task<T> GetAsync<T>(string? requestUri, CancellationToken cancellationToken = default)
        {
            return Client.GetFromJsonAsync<T>(requestUri, cancellationToken);
        }

        protected Task<IEnumerable<T>> GetListAsync<T>(string? requestUri, CancellationToken cancellationToken = default)
        {
            return Client.GetFromJsonAsync<IEnumerable<T>>(requestUri, serializerOptions, cancellationToken);
        }

        private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), serializerOptions, cancellationToken);
        }
    }
}
