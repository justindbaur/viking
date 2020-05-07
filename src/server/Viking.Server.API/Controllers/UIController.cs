using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viking.Contexts;

namespace Viking.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIController : ControllerBase
    {
        private readonly ApplicationContext context;

        public UIController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("recents")]
        public async Task<IActionResult> GetRecents()
        {
            var recentInteractions = await context.Interactions
                .Where(i => i.UserId == User.Identity.Name && i.Type == Entities.InteractionType.OpenTracker)
                .OrderBy(i => i.Time)
                .Take(5)
                .ToListAsync();

            return Ok(recentInteractions);
        }

        [HttpGet("favorites")]
        public Task<IActionResult> GetFavorites()
        {
            throw new NotImplementedException();
        }
    }
}