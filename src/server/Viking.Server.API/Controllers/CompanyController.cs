using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Viking.Entities;
using Viking.Services;

namespace Viking.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationService service;

        public CompanyController(ApplicationService service)
        {
            this.service = service;
        }

        [HttpGet("{name}")]
        public Task<IActionResult> Get(string name)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> Create(Company company)
        {
            throw new NotImplementedException();
        }
    }
}