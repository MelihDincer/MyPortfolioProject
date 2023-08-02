using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error401()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
    }
}
