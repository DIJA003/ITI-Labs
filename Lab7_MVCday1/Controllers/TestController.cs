using Microsoft.AspNetCore.Mvc;

namespace Lab7_MVCday1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
