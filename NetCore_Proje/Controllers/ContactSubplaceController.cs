using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NetCore_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim Bilgileri";
            ViewBag.v2 = "İletişim Bilgileri";
            ViewBag.v3 = "İletişim Bilgileri Düzenleme Sayfası";
            var values = contactManager.TGetById(1); //id değeri "1" olan verileri getir.
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactID = 1;
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}