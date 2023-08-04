using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Duyuru Listesi";
            ViewBag.v2 = "Duyurular";
            ViewBag.v3 = "Duyuru Listesi Sayfası";
            var values = announcementManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            ViewBag.v1 = "Duyuru Ekleme";
            ViewBag.v2 = "Duyurular";
            ViewBag.v3 = "Duyuru Ekleme Sayfası";
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcementManager.TAdd(announcement);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int id )
        {
            ViewBag.v1 = "Duyuru Düzenleme";
            ViewBag.v2 = "Duyurular";
            ViewBag.v3 = "Duyuru Düzenleme Sayfası";
            var values = announcementManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement p)
        {
            announcementManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}