using Microsoft.AspNetCore.Mvc;

namespace RequestFiltering.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/Home")]
        public IActionResult Index() => View();
    }
}
