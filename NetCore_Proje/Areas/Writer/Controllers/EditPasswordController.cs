using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje.Areas.Writer.Models;
using System.Threading.Tasks;

namespace NetCore_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class EditPasswordController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public EditPasswordController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditPasswordViewModel model = new UserEditPasswordViewModel();
            model.Password = "";
            model.PasswordConfirm = "";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditPasswordViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
