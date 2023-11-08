using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Proje_Api.DAL.ApiContext;
using NetCore_Proje_Api.DAL.Entity;
using System.Linq;
using System.Windows.Markup;

namespace NetCore_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value != null)
            {
                return Ok(value);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value != null)
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var c = new Context();
            var value = c.Categories.Find(p.CategoryID);
            //var values = c.Find<Category>(p.CategoryID);
            if (value != null)
            {
                value.CategoryName = p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}