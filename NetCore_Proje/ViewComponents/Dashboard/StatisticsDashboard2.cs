using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count(); //Proje sayısı
            ViewBag.v2 = c.Messages.Count(); //Mesaj sayısı
            ViewBag.v3 = c.Services.Count(); //Hizmet sayısı
            return View();
        }
    }
}
