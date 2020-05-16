using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Viking.Contexts;
using Viking.Entities;

namespace Viking.Services
{
    public class ApplicationService
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
            await client.PostAsync(requestUri, GetJsonContent(body));
        }

        private StringContent GetJsonContent(object content)
        {
            var sw = new StringWriter();
            serializer.Serialize(sw, content);

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
