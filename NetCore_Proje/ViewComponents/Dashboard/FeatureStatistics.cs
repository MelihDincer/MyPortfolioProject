using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new();
            //var values = contactManager.TGetList();
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.Messages.Where(x => x.Status == false).Count(); //okunmamış mesaj sayısını getir.
            ViewBag.v3 = c.Messages.Where(x => x.Status == true).Count(); //okunmuş mesaj sayısını getir.
            ViewBag.v4 = c.Experiences.Count(); 
            return View();
        }
    }
}
