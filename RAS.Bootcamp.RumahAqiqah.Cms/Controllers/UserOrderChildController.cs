using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class UserOrderChildController : Controller
    {
        private readonly IRepository<UserOrderChild> _uochild;
        private readonly ApplicationDbContext _context;

        public UserOrderChildController(ApplicationDbContext context, IRepository<UserOrderChild> uochild)
        {
            _context = context;
            _uochild = uochild;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}