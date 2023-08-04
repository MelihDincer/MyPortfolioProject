using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = user.ImageURL;
            var values = writerMessageManager.TGetList().Where(x=>x.Receiver == "admin@gmail.com").Take(5).ToList();
            return View(values);
        }
    }
}
