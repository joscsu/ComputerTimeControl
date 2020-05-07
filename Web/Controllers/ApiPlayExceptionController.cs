using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAzureAD.Models;

namespace WebAppAzureAD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPlayExceptionController : ControllerBase
    {
        // GET: api/ApiPlayException
        [HttpGet]
        public IEnumerable<PlayException> Get()
        {
            return PlayExceptionController.List;
        }

        // GET: api/ApiPlayException/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApiPlayException
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ApiPlayException/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
