using Microsoft.AspNetCore.Mvc;

namespace RequestFiltering.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index() => View();
    }
}
