using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var img1 = c.WriterMessages.Where(x => x.Receiver == p).Select(z=>z.Sender).FirstOrDefault();
            var img2 = c.Users.Where(x=>x.Email == img1).Select(z=>z.ImageURL).FirstOrDefault();
            ViewBag.v1 = img2;
            var values = writerMessageManager.GetListRecieverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();

            return View(values);
        }
    }
}
