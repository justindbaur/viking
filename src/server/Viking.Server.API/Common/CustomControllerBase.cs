using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viking.Services;

namespace Viking.Server.API.Common
{
    public class CustomControllerBase<T> : ControllerBase
    {
        public CustomControllerBase(ApplicationService service)
        {
            Service = service;
        }

        public ApplicationService Service { get; }

        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
