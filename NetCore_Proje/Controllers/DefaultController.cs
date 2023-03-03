using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NetCore_Proje.Controllers
{
    public class DefaultController : Controller
    {
        // Backend mimaride yazdığımız kodları burada çağırıp, UI (Kullanıcı arayüzü) ile birleştireceğiz.
        public IActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // Mesajın kaydedildiği andaki tarihi veritabanına yansıtma işlemi.
            p.Status = true;
            messageManager.TAdd(p);
            return PartialView();
        }
    }
}
