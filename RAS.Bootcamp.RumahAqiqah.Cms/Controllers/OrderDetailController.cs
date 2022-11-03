using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IRepository<OrderDetail> _odeteail;
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context, IRepository<OrderDetail> odetail)
        {
            _context = context;
            _odeteail = odetail;
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