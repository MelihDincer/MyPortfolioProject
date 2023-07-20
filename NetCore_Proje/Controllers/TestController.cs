using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
