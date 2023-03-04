using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
