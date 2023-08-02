using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    //ADMIN'E GELEN MESAJLAR
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Mesaj Listesi";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Mesaj Listesi Sayfası";
            var values = messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = messageManager.TGetById(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ContactDetails(int id) 
        {
            ViewBag.v1 = "Mesaj Detay";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Mesaj Detay Sayfası";
            var values = messageManager.TGetById(id);
            return View(values);
        }
    }
}
