using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Cms.Models;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;
using System.Diagnostics;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Account> _account;
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context, IRepository<Account> account)
        {
            _context = context;
            _account = account;
        }

        public IActionResult Login(){

            return View();
        }

        public IActionResult Index()
        {
            var accounts = _account.GetList();
            return View(accounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            account.CreatedBy = 1;
            account.UpdatedBy = 1;

            account.CreatedDt = DateTime.Now;
            account.UpdatedDt = DateTime.Now;
            account.LastLogin = DateTime.Now;

            if (ModelState.IsValid)
            {
                _account.Add(account);
                return RedirectToAction(nameof(Index));
            }

            foreach (var modelstate in ViewData.ModelState.Values)
            {
                foreach (var modelerror in modelstate.Errors)
                {
                    string errormessage = modelerror.ErrorMessage;
                    ModelState.AddModelError("", errormessage);
                }
            }
            
            return View(account);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var account = _account.Get(id);
            account.UpdatedDt = DateTime.Now;
            account.IsDeleted = true;
            _account.Update(account);

            return RedirectToAction(nameof(Index));
        }

    }
}