using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NetCore_Proje.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Message p)
        //{
        //    p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); // Mesajın kaydedildiği andaki tarihi veritabanına yansıtma işlemi.
        //    p.Status = true;
        //    messageManager.TAdd(p);
        //    return View();
        //}
    }
}
