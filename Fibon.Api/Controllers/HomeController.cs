using Microsoft.AspNetCore.Mvc;

namespace Fibon.Api.Controllers
{


    public class HomeController : Controller
    {
        [HttpGetAttribute("")]
        public IActionResult Get() => Content("Hello");
    }
}