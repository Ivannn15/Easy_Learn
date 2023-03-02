using Microsoft.AspNetCore.Mvc;

namespace Easy_Learn.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
