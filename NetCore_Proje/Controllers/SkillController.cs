using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
