using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Viking.Contexts;

namespace Viking.Server.Services
{
    public class ApplicationRepository
    {
        public ApplicationContext Context { get; }
        private readonly IMapper mapper;
        private readonly ILogger<ApplicationRepository> logger;

        public ApplicationRepository(ApplicationContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.Context = context;
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger<ApplicationRepository>();
        }

        public async Task<Entity> Patch<Entity, SaveModel>(object[] keys, SaveModel saveModel)
            where Entity : class
        {
            var existingItem = await Context.FindAsync<Entity>(keys);

            if (existingItem == null)
            {
                throw new ItemNotFoundException();
            }

            mapper.Map(saveModel, existingItem);

            await Context.SaveChangesAsync();

            return existingItem;
        }

        public async Task Delete<Entity>(object[] keys)
            where Entity : class
        {
            var item = await Context.FindAsync<Entity>(keys);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            var result = Context.Remove(item);

            if (result.State != EntityState.Deleted)
            {
                // TODO: Datadump of why the item might not have been deleted.
                logger.LogError("");
                throw new Exception($"Error deleting {typeof(Entity).Name} by keys ({string.Join(',', keys)})");
            }
        }
    }
}
