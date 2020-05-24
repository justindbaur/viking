using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viking.Contexts;
using Viking.Entities;
using Viking.Server.API.Common;
using Vikings.Models;

namespace Viking.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : CustomControllerBase<PurchaseOrder, CreatePurchaseOrderModel, SavePurchaseOrderModel>
    { 
        public PurchaseOrderController(ApplicationContext context) : base(context)
        {

        }


        [HttpGet("({company},{poNum})")]
        public async Task<IActionResult> Get(string company, string poNum)
        {
            return await FindItem(new[] { company, poNum });
        }

        [HttpDelete("({company},{poNum})")]
        public async Task<IActionResult> Delete(string company, string poNum)
        {
            return await DeleteItem(new[] { company, poNum });
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(string company, string poNum, SavePurchaseOrderModel purchaseOrder)
        {
            return await PatchItem(new[] { company, poNum }, purchaseOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePurchaseOrderModel purchaseOrder)
        {
            var createdItem = await CreateItem(purchaseOrder);

            return Created(createdItem, createdItem.Company, createdItem.PONum);
        }

        [HttpGet("({company},{poNum})/polines")]
        public async Task<IActionResult> GetPurchaseOrderLines(string company, string poNum)
        {
            var po = await Context.PurchaseOrders
                .Where(p => p.Company == company && p.PONum == poNum)
                .Include(p => p.PurchaseOrderLines)
                .FirstOrDefaultAsync();

            if (po == null)
            {
                return NotFound();
            }

            return Ok(po.PurchaseOrderLines);
        }
    }
}