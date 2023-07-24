﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje.Area.Writer.Models;
using System.Threading.Tasks;

namespace NetCore_Proje.Area.Writer.Controllers
{
    [Area("Writer")]
    public class LoginController : Controller
    {
        //Dependency Injection Uygulaması --> Başlangıç
        private readonly SignInManager<WriterUser> _signInManager;
        public LoginController(SignInManager<WriterUser> signInManager)
        //Dependency Injection Uygulaması --> Son
        {
            _signInManager = signInManager;
        }
        //Kullanıcı Adı: admin41 <----> Şifre: 1234Aa*

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
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password,true,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı adı veya şifre");
                }
            }
            return View();
        }
    }
}