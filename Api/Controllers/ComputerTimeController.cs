using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerTimeController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ComputerTime>> Get()
        {
            using (var context = new MyDbContext())
            {
                var times = await context.ComputerTimes.ToListAsync();
                return times;
            }
        }
    }
}
