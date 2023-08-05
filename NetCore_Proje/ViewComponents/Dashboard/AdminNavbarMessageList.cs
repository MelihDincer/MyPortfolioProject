using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        //WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var list = (from x in c.Users
                        join y in c.WriterMessages on x.Email equals y.Sender
                        where y.Receiver == p
                        orderby y.WriterMessageID descending
                        select new MessageViewModel
                        {
                            MessageID = y.WriterMessageID,
                            Message = y,
                            SenderImage = x.ImageURL,
                            SenderName = y.SenderName,
                            Date = y.Date
                        }).Take(3).ToList();
            return View(list);

            //var message = c.WriterMessages.Where(x => x.Receiver == p).OrderByDescending(y => y.WriterMessageID).FirstOrDefault();
            //var img = c.Users.Where(x => x.Email == message.Sender).Select(y => y.ImageURL).FirstOrDefault();
            //ViewBag.v = img;
            //var values = writerMessageManager.GetListRecieverMessage(p).OrderByDescending(x => x.WriterMessageID).Take(3).ToList();
            //return View(values);
        }
    }
}