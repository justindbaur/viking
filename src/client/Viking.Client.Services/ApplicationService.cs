using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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
            await client.PostAsync(requestUri, GetJsonContent(body));
        }

        public async Task ExecuteAsync(string requestUri, object body, CancellationToken cancellationToken)
        {
            await client.PostAsync(requestUri, GetJsonContent(body), cancellationToken);
        }

        private StringContent GetJsonContent(object content)
        {
            // Create a string writer to store the serialized string
            var sw = new StringWriter();
            // Use existing serializer with our rules to do the serialization
            serializer.Serialize(sw, content);
            // Return a JSON formatted StringContent with our content encoding and media type declaration
            return new StringContent(sw.ToString(), Encoding.UTF8, "application/json");
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
