using Easy_Learn.Models;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Learn.Controllers
{
    public class WordController : Controller
    {
        public IActionResult Index()
        {
            wordModel context = HttpContext.RequestServices.GetService(typeof(Easy_Learn.Models.wordModel)) as wordModel;
            return View(context.GeCities());
        }
    }
}
