using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
