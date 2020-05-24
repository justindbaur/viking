using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Viking.Contexts;
using Viking.Entities;
using Viking.Services;

namespace Viking.Server.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationContext context;

        public CompanyController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("({name})")]
        public async Task<IActionResult> Get(string name)
        {
            var company = await context.Companies.FindAsync(name);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Companies.ToListAsync());
        }
    }
}