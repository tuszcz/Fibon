using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController:Controller
    {
        private readonly IBusClient _client;
        public FibonacciController(IBusClient client){
            _client = client;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number){
            return Content("0");
        }

        [HttpPost("{number}")]
        public IActionResult Post(int number){
            return Accepted($"fibonacci/{number}", null);
        }

    }
}