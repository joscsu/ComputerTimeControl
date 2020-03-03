using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ComputerTimeRuleController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ComputerTimeRule>> Post([FromBody]ComputerTimeRule rule)
        {
            using (var context = new MyDbContext())
            {
                var ent = await context.ComputerTimeRules.AddAsync(rule);
                await context.SaveChangesAsync();
                return Created("", ent.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerTimeRule>>> Get()
        {
            using (var context = new MyDbContext())
            {
                var rules = await context.ComputerTimeRules.ToListAsync();
                return Ok(rules);
            }
        }
    }
}
