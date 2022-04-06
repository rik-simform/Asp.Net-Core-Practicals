using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _log;

        public HelloWorldController(ILogger<HelloWorldController> log)
        {
            _log = log;
        }

        [HttpGet("Get")]
        public IEnumerable<string> get()
        {
            _log.LogInformation("Get Method Of Home Controller Called");
            _log.LogWarning("Warning Message in Get Method");
           
            return new string[] {  "Hello World" };
        }
    }
}
