using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Viking.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly HttpClient client;
        private readonly JsonSerializer serializer;

        public ApplicationService(IApplicationServiceConfig config)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(config.BaseUrl)
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

            // Setup any config for the serializer here
            serializer = new JsonSerializer();
        }

        public async Task ExecuteAsync(string requestUri, object body)
        {
            // Do a POST at the given request uri with the object they gave serialized as the body
            await client.PostAsJsonAsync(requestUri, body);
        }

        public async Task ExecuteAsync(string requestUri, object body, CancellationToken cancellationToken)
        {
            var response = await client.PostAsJsonAsync(requestUri, body, cancellationToken);
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {
                var value = await client.GetFromJsonAsync<T>(requestUri);

                return value;
            }
            catch
            {
                throw;
            }
        }

        private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            using (Stream s = await response.Content.ReadAsStreamAsync())
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
