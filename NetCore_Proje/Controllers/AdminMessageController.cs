using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace NetCore_Proje.Controllers
{
    //Sisteme kayıtlı user'lar ile iletişime geçilen kısım (Writer Message)
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        //Gelen Mesajlar
        public IActionResult ReceiverMessageList()
        {
            ViewBag.v1 = "Alınan Mesajlar Listesi";
            ViewBag.v2 = "Alınan Mesajlar";
            ViewBag.v3 = "Alınan Mesajlar Listesi Sayfası";
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListRecieverMessage(p);
            return View(values);
        }
        //Gönderilen Mesajlar
        public IActionResult SenderMessageList()
        {
            ViewBag.v1 = "Gönderilen Mesajlar Listesi";
            ViewBag.v2 = "Gönderilen Mesajlar";
            ViewBag.v3 = "Gönderilen Mesajlar Listesi Sayfası";
            string adm = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(adm);
            return View(values);
        }
        [HttpGet]
        public IActionResult AdminMessageDetails(int id)
        {
            ViewBag.v1 = "Admin Mesaj Detay";
            ViewBag.v2 = "Admin Mesaj Detay";
            ViewBag.v3 = "Admin Mesaj Detay Sayfası";
            var values = writerMessageManager.TGetById(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            string adm = "admin@gmail.com";
            var values = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(values);
            if (values.Receiver == adm)
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
                return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            ViewBag.v1 = "Admin Mesaj Gönderme";
            ViewBag.v2 = "Admin Mesaj";
            ViewBag.v3 = "Admin Mesaj Gönderme Sayfası";
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
