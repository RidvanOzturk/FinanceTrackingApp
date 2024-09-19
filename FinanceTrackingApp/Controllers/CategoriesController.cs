using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers
{
    public class CategoriesController(ICategoriesService categoriesService) : Controller
    {
        [HttpGet("list")]
        public IActionResult ListCategories()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult AddCategory(/*CategoryModel model*/)
        {
            return View();
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateCategory(/*Guid id, CategoryModel model*/)
        {
            return RedirectToAction("Index");
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            return View(id);
        }
    }
}
