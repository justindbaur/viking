using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Viking.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Viking.Server.API.Common
{
    [Route("api/[controller]")]
    public class CustomControllerBase<Entity, CreateModel, SaveModel> : ControllerBase
        where Entity : class
    {
        public ApplicationContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CustomControllerBase(ApplicationContext context)
        {
            Context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Context.Set<Entity>().ToListAsync());
        }

        #region Helper Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected CreatedResult Created([ActionResultObjectValue] object value, params object[] keys)
        {
            return base.Created($"api/{typeof(Entity).Name.ToLower()}/({string.Join(',', keys)})", value);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected async Task<IActionResult> FindItem(object[] keys)
        {
            var item = await Context.FindAsync<Entity>(keys);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected async Task<IActionResult> PatchItem(object[] keys, SaveModel entity)
        {
            try
            {
                var item = await Context.FindAsync<Entity>(keys);

                if (item == null)
                {
                    return NotFound();
                }

                // TODO: Do patch




                await Context.SaveChangesAsync();

                // Return patched item
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected async Task<IActionResult> DeleteItem(object[] keys)
        {
            try
            {
                var item = await Context.FindAsync<Entity>(keys);

                if (item == null)
                {
                    return NotFound();
                }

                var result = Context.Remove(item);

                if (result.State != EntityState.Deleted)
                {
                    return BadRequest("Error deleting the item.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
