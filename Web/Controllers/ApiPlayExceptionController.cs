using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerTime.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Data;

namespace WebAppAzureAD.Controllers
{
    [Route("api/playexception")]
    [ApiController]
    public class ApiPlayExceptionController : ControllerBase
    {
        private readonly IPlayExceptionRepository repository;

        public ApiPlayExceptionController(IWebHostEnvironment hostEnvironment, IPlayExceptionRepository repository)
        {
            var dbPath = System.IO.Path.Combine(hostEnvironment.WebRootPath, "App_Data", "ex.json");
            this.repository = repository;
            this.repository.DbPath = dbPath;
        }

        // GET: api/ApiPlayException
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<PlayException> Get()
        {
            var list = repository.Get();
            return list;
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
