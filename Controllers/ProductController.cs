//using BuyWise.Models;
//using BuyWise.Models.Products;
//using Microsoft.AspNetCore.Mvc;


//namespace BuyWise.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly BuyWiseDBContext _dbContext;

//        public ProductController(BuyWiseDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public IActionResult Index()
//        {
//            var products = from p in _dbContext.Products
//                           from b in _dbContext.Brands
//                           where p.BrandId == b.Id
//                           select new { Id = p.Id, BrandName = b.Name, ProductName = p.Name };

//            return View(products);
//        }


//        public IActionResult New()
//        {
//            ViewBag.Categories = _dbContext.Categories.OrderBy(c => c.Name).ToList();
//            ViewBag.Brands = _dbContext.Brands.OrderBy(b => b.Name).ToList();
//            return View();
//        }
//        [HttpPost]
//        public IActionResult New(Product product, List<IFormFile> ProductImages)
//        {
//            _dbContext.Products.Add(product);
//            _dbContext.SaveChanges();

//            if (ProductImages != null && ProductImages.Count > 0)
//            {
//                var productImages = new List<ProductImage>();
//                var productId = product.Id;
//                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/products");
//                if (!Directory.Exists(uploadPath))
//                    Directory.CreateDirectory(uploadPath);

//                foreach (var file in ProductImages)
//                {
//                    if (file.Length > 0)
//                    {
//                        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
//                        var filePath = Path.Combine(uploadPath, fileName);
//                        using (var stream = new FileStream(filePath, FileMode.Create))
//                        {
//                            file.CopyTo(stream);
//                        }
//                        var imageUrl = $"products/{fileName}";
//                        productImages.Add(new ProductImage
//                        {
//                            ProductId = productId,
//                            ImageUrl = imageUrl
//                        });
//                    }
//                }
//                _dbContext.ProductImages.AddRange(productImages);
//                _dbContext.SaveChanges();
//            }
//            return RedirectToAction("Index");
//        }


//        public IActionResult Edit()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Edit(Product product)
//        {
//            _dbContext.Products.Update(product);
//            _dbContext.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Details(long id)
//        {
//            var product = _dbContext.Products.
//                        Select(p => new
//                        {
//                            p.Id,
//                            p.Name,
//                            p.Description,
//                            p.ShortDescription,
//                            p.CurrentPrice,
//                            PriceAfterDiscount = (p.CurrentPrice * (decimal)0.75),
//                            CategoryName = p.Category.Name,
//                            Brandname = p.Brand.Name,
//                            ImagesList = p.ProductImages.ToList()
//                        })
//                .FirstOrDefault(p => p.Id == id);
//            return View("ProductDetail", product);
//        }
//    }
//}
using BuyWise.Models;
using BuyWise.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace BuyWise.Controllers
{
    public class ProductController : Controller
    {
        private readonly BuyWiseDBContext _dbContext;

        public ProductController(BuyWiseDBContext dbContext)
        {
            _dbContext = dbContext;
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
            ViewBag.Categories = _dbContext.Categories.OrderBy(c => c.Name).ToList();
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
