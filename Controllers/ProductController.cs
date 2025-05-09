using BuyWise.Models;
using BuyWise.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace BuyWise.Controllers
{
    public class ProductController : Controller
    {
        BuyWiseDBContext _dbContext;

        public ProductController()
        {
            _dbContext = new();
        }
        public IActionResult Index()
        {
            var products = from p in _dbContext.Products
                           from b in _dbContext.Brands
                           where p.BrandId == b.Id
                           select new { Id = p.Id, BrandName = b.Name, ProductName = p.Name };

            return View(products);
        }


        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            var product = _dbContext.Products.
                        Select(p => new
                        {
                            p.Id,
                            p.Name,
                            p.Description,
                            p.ShortDescription,
                            p.CurrentPrice,
                            PriceAfterDiscount = (p.CurrentPrice * (decimal)0.75),
                            CategoryName = p.Category.Name,
                            Brandname = p.Brand.Name,
                            ImagesList = p.ProductImages.ToList()
                        })
                .FirstOrDefault(p => p.Id == id);
            return View("ProductDetail", product);
        }
    }
}
