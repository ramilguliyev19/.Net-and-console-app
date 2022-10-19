using Microsoft.AspNetCore.Mvc;

namespace EduhomeZero.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
