using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Viking.Entities;

namespace Viking.Client.Services
{
    public class ApplicationService : ServiceBase, IApplicationService
    {
        public const string ClientName = "Application";

        public ApplicationService(IHttpClientFactory clientFactory) : base(clientFactory.CreateClient(ClientName))
        {
            
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await GetListAsync<Company>("company");
        }
    }
}
