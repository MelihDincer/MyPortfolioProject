﻿using EntityLayer.Concrete;
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
    public class LoginController : Controller
    {
        //Dependency Injection Uygulaması --> Başlangıç
        private readonly SignInManager<WriterUser> _signInManager;
        public LoginController(SignInManager<WriterUser> signInManager)

        {
            _signInManager = signInManager;
        }
        //Dependency Injection Uygulaması --> Son

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Dashboard", new { area = "Writer" });
                    return LocalRedirect("/Writer/Dashboard/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı adı veya şifre");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}