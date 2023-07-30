using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referanslar";
            ViewBag.v3 = "Referanslar Listesi Sayfası";
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            ViewBag.v1 = "Referans Detayları";
            ViewBag.v2 = "Referanslar";
            ViewBag.v3 = "Referans Detayları Sayfası";
            var values = testimonialManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial p)
        {
            testimonialManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}