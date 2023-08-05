using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NetCore_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referanslar";
            ViewBag.v3 = "Referans Ekleme Sayfası";
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
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