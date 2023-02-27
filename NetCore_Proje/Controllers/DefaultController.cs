using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    public class DefaultController : Controller
    {
        // Backend mimaride yazdığımız kodları burada çağırıp, UI (Kullanıcı arayüzü) ile birleştireceğiz.
        public IActionResult Index()
        {
            return View();
        }
    }
}
