using BuyWise.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuyWise.Controllers
{
    public class CategoryController : Controller
    {
        BuyWiseDBContext _dbContext;
        public CategoryController()
        {
            _dbContext = new();
        }
        public IActionResult Index()
        {
            var categories = from c in _dbContext.Categories
                             select c;
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        // Create View Here
        [HttpPost]
        public IActionResult CreateCategory(Category newCategory)
        {
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return View();
        }
    }
}
