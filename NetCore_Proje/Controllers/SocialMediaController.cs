using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Sosyal Medya Listesi";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Sosyal Medya Hesapları Sayfası";
            var values = socialMediaManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewBag.v1 = "Sosyal Medya Ekle";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Hesap Ekleme Sayfası";
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
           var values = socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewBag.v1 = "Hesap Düzenleme";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Hesap Düzenleme Sayfası";
            var values = socialMediaManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}