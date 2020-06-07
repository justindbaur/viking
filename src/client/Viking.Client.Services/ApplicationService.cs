using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Viking.Client.Services
{
    public class ApplicationService : ServiceBase, IApplicationService
    {
        public const string ClientName = "Application";

        public ApplicationService(IHttpClientFactory clientFactory) : base(clientFactory.CreateClient(ClientName))
        {
            
        }
    }
}
