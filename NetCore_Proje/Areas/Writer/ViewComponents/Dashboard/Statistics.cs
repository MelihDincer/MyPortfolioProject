using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Statistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.projectCount = c.Portfolios.Count();
            ViewBag.skillCount = c.Skills.Count();
            ViewBag.experienceCount = c.Experiences.Count();
            ViewBag.userCount = c.Users.Count();
            return View();
        }
    }
}
