using Microsoft.AspNetCore.Mvc;

namespace TestStream.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}