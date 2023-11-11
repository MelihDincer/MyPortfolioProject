using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NetCore_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Last4Users : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Last4Users(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userManager.Users.OrderByDescending(x => x.Id).Take(4).ToList();
            return View(values);
        }
    }
}
