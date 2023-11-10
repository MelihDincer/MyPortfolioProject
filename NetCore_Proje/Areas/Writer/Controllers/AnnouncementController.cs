using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace NetCore_Proje.Area.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    [Route("Writer/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult AnnouncementDetails(int id)
        {
            var value = announcementManager.TGetById(id);
            return View(value);
        }
    }
}
