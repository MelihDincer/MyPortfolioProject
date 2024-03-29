﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Düzenleme Sayfası";
            var values = aboutManager.TGetById(1); //id değeri "1" olan verileri getir.
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            about.AboutID = 1;
            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
