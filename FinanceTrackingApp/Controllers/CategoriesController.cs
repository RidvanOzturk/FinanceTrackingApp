using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers
{
    public class CategoriesController(ICategoriesService categoriesService) : Controller
    {
        // GET - category/list
        [HttpGet("list")]
        public IActionResult ListCategories()
        {
            return View();
        }

        // GET - category/id
        [HttpGet]
        public IActionResult Get([FromRoute] Guid id)
        {
            return View();
        }

        // POST - category (model)
        [HttpPost]
        public IActionResult AddCategory(/*CategoryModel model*/)
        {
            return View();
        }

        // PUT - category/id (model)
        [HttpPut]
        public IActionResult UpdateCategory(/*[FromRoute] Guid id, CategoryModel model*/)
        {
            return RedirectToAction("Index");
        }

        // .../categories/3 - Route parameter
        // .../categories?userid=3 - Query parameter

        // DELETE - category/id
        [HttpDelete]
        public IActionResult DeleteCategory([FromQuery] Guid id)
        {
            return View(id);
        }
    }
}
