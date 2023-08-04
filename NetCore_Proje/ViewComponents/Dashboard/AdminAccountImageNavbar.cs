using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class AdminAccountImageNavbar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminAccountImageNavbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = user.ImageURL;
            ViewBag.v2 = user.Name + " " + user.Surname;
            return View(user);
        }
    }
}
