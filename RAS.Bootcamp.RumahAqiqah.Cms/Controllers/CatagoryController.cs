using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Cms.Models;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;
using RAS.Bootcamp.RumahAqiqah.Data;
using System.Diagnostics;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            CatagoryVM catagoryVM = new CatagoryVM();
            catagoryVM.catagories = Catagory.GetAll();
            return View(catagoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CatagoryVM vm = new CatagoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Catagory = Catagory.GetT(x => x.Id == id);
                if (vm.Catagory == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CatagoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Catagory.Id == 0)
                {
                    Catagory.Add(vm.Catagory);
                    TempData["success"] = "NEW CATAGORY CREATED";
                }
                else
                {
                    Catagory.Update(vm.Catagory);
                    TempData["success"] = "CATAGORY UPDATED";
                }
                _context.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var catagory = Catagory.GetT(x => x.Id == id);
                if (catagory == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(catagory);
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var catagory = Catagory.GetT(x => x.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }
            Catagory.Delete(catagory);
            _context.Save();
            TempData["success"] = "Catagory Deleted";
            return RedirectToAction("Index");
        }
    }
}