using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Viking.Services;

namespace Viking.Client.Services
{
    public static class ServicesHelper
    {
        /// <summary>
        /// Adds in all default services that will be used by all clients
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDefaultClientServices(this IServiceCollection services)
        {
            // Adds in the service built for clients to consume the API
            services.AddSingleton<IApplicationService, ApplicationService>();

            // Adds in HttpClients
            services.AddHttpClient(ApplicationService.ClientName, c =>
            {
                c.BaseAddress = new Uri("");
            });




            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMessageImplementation"></typeparam>
        /// <typeparam name="TBugReportImplementation"></typeparam>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureClientSpecific<TMessageImplementation, TBugReportImplementation>(this IServiceCollection serviceCollection)
            where TMessageImplementation : class, IMessageService
            where TBugReportImplementation : class, IBugReportService
        {
            // TODO: Choose which service type would be best for each item, bug report will probably need user information
            serviceCollection.AddSingleton<IMessageService, TMessageImplementation>();

            serviceCollection.AddTransient<IBugReportService, TBugReportImplementation>();

            return serviceCollection;
        }


    }
}
