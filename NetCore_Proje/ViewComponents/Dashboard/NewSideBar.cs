using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NetCore_Proje.ViewComponents.Dashboard
{
    public class NewSideBar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NewSideBar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = user.Name + " " + user.Surname;
            ViewBag.v2 = user.ImageURL;
            return View();
        }
    }
}