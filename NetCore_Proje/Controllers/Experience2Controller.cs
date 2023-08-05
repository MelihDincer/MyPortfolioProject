using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyimler Sayfası";
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExperienceID)
        {
            var v = experienceManager.TGetById(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetById(id);
            experienceManager.TDelete(v);
            return Ok();
        }
        public IActionResult UpdateExperience(int id, string name, string date)
        {
            var v = experienceManager.TGetById(id);
            if (v != null)
            {
                v.Name = name;
                v.Date = date;
                experienceManager.TUpdate(v);
                var value = JsonConvert.SerializeObject(v);
                return Json(value);
            }
            return NoContent();
        }
    }
}