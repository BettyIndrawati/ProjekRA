using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _product;
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context, IRepository<Product> product)
        {
            _context = context;
            _product = product;
        }
        public IActionResult Index()
        {
            // ViewData["ProductCategories"] = new SelectList(_context.ProductCategories, "Id", "Name");
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Product products)
        {
            var uploadImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
            if(!Directory.Exists(uploadImage))
                Directory.CreateDirectory(uploadImage);
            
            var fileImage = $"{products.Code}-{products.ImageFile.FileName}";
            var filePath = Path.Combine(uploadImage, fileImage);

            using var stream = System.IO.File.Create(filePath);
            if(products.ImageFile != null)
                products.ImageFile.CopyTo(stream);
            
            var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Image/{fileImage}";

            var newCategory = new ProductCategory
            {
                Name = "Kambing Betina",
                Description = "Untuk Aqiqah",
                CreatedBy = 1,
                UpdatedBy = 1,
            };
                newCategory.CreatedDt = DateTime.Now;
                newCategory.UpdatedDt = DateTime.Now;
                _context.ProductCategories.Add(newCategory);
                _context.SaveChanges();

            var newProduct = new Product
            {
                ProductCategoryId = newCategory.Id,
                Code = products.Code,
                Title = products.Title,
                FileName = fileImage,
                Url = url,
                Price = products.Price,
                Description = products.Description,
                ServiceType = products.ServiceType,
                CreatedBy = 1,
                UpdatedBy = 1,
            };
                newProduct.CreatedDt = DateTime.Now;
                newProduct.UpdatedDt = DateTime.Now;
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var updated = _context.Products.FirstOrDefault(x => x.Id == id);
            Product productlist = new Product
            {
                ProductCategoryId = updated.Id,
                Code = updated.Code,
                Title = updated.Title,
                Price = updated.Price,
                Description = updated.Description,
                ServiceType = updated.ServiceType,
            };

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product products)
        {
            var uploadImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
            if(!Directory.Exists(uploadImage))
                Directory.CreateDirectory(uploadImage);
            
            var fileImage = $"{products.Code}-{products.ImageFile.FileName}";
            var filePath = Path.Combine(uploadImage, fileImage);

            using var stream = System.IO.File.Create(filePath);
            if(products.ImageFile != null)
                products.ImageFile.CopyTo(stream);
            
            var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Image/{fileImage}";

            var brng = _context.Products.FirstOrDefault(x => x.Id == products.Id);
            var Delete = Path.Combine(uploadImage, brng.FileName);

            System.IO.File.Delete(Delete);
            brng.ProductCategoryId = products.Id;
            brng.Code = products.Code;
            brng.Title = products.Title;
            brng.FileName = fileImage;
            brng.Url = url;
            brng.Price = products.Price;
            brng.Description = products.Description;
            brng.ServiceType = products.ServiceType;
            brng.UpdatedBy = 1;
            brng.UpdatedDt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Details(int id)
        {
            var products = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var products = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(products);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            Product barangdelete = _context.Products.First( x => x.Id == id);
            var uploadImage = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Image");
            var filepath = Path.Combine(uploadImage, barangdelete.FileName);
            System.IO.File.Delete(filepath);

            _context.Products.Update(barangdelete);
            barangdelete.UpdatedDt = DateTime.Now;
            barangdelete.IsDeleted = true;
            _context.SaveChanges();
            return View(barangdelete);
        }
    }
}