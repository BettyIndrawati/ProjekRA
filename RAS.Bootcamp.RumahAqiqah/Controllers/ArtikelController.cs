using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.RumahAqiqah.Models;
using System.Diagnostics;

namespace RAS.Bootcamp.RumahAqiqah.Controllers
{
    public class ArtikelController : Controller
    {
        // private readonly ILogger<ArtikelController> _logger;

        // public ArtikelController(ILogger<ArtikelController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View("Index", "Artikel");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}