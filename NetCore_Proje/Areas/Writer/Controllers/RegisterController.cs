using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje.Area.Writer.Models;
using System.Threading.Tasks;

namespace NetCore_Proje.Area.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;
        
        //Dependency Injection
        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser w = new()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageURL = p.ImageURL
                };

                if(p.Password == p.ConfirmPassword) // result değeri bu şart geçerli olduğunda atanacağı için, şifrelerin eşleşmemesi durumunda db'ye veri kaydedilmeyecek. Şifreler eşleşmediği halde db'ye veri eklendiği için bu şart içerisinde işlemler gerçekleştirilmiştir.
                {
                    var result = await _userManager.CreateAsync(w, p.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View();
        }
    }
}
