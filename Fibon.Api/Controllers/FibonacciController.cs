using System.Threading.Tasks;
using Fibon.Api.Framework;
using Fibon.Api.Repository;
using Fibon.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IRepository _repository;

        public FibonacciController(IBusClient busClient, IRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? calculatedValue = _repository.Get(number);
            if (calculatedValue.HasValue)
            {
                return Content(calculatedValue.ToString());
            }

            return NotFound();
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? calculatedValue = _repository.Get(number);
            if (!calculatedValue.HasValue)
            {
                await _busClient.PublishAsync(new CalculateValueCommand(number));
            }

            return Accepted($"fibonacci/{number}", null);
        }        
    }
}