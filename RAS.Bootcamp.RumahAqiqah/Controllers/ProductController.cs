using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.RumahAqiqah.Models;

namespace RAS.Bootcamp.RumahAqiqah.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}