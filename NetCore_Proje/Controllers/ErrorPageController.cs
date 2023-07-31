using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
