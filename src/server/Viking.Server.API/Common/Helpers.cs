using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viking.Entities;

namespace Viking.Server.API.Common
{
    public static class Helpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appBuilder"></param>
        public static ODataConventionModelBuilder ConfigureOData(this IApplicationBuilder appBuilder)
        {
            var odataBuilder = new ODataConventionModelBuilder(appBuilder.ApplicationServices);

            // TODO: Auto loop of all types in Viking.Entities that inherits from AuditableEntity
            odataBuilder.EntitySet<Company>("companies");

            return odataBuilder;
        }

        /// <summary>
        /// Registers an entity set as a part of the model and returns an object that can
        ///  be used to configure the entity set. This method can be called multiple times
        ///  for the same type to perform multiple lines of configuration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static EntitySetConfiguration<T> EntitySet<T>(this ODataConventionModelBuilder builder)
            where T : class
        {
            return builder.EntitySet<T>(typeof(T).Name);
        }
    }
}
