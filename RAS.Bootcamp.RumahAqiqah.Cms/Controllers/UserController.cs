using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _user;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, IRepository<User> user)
        {
            _context = context;
            _user = user;
        }

        public IActionResult Index()
        {
            // var users = _user.GetList();
            var users = _context.Users.Include(t => t.Account).Include(t => t.Role).ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            ViewData["Roles"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["Accounts"] = new SelectList(_context.Accounts, "Id", "Username");
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            // user.AccountId = 1;
            // user.RoleId = 1;
            user.CreatedBy = 1;
            user.UpdatedBy = 1;

            user.CreatedDt = DateTime.Now;
            user.UpdatedDt = DateTime.Now;
            user.IsDeleted = false;

            if (ModelState.IsValid)
            {
                _user.Add(user);
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

            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            ViewData["Roles"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["Accounts"] = new SelectList(_context.Accounts, "Id", "Username");
            
            return View(user);
        }

        public IActionResult Details(int id)
        {
            var user = _user.Get(id);

            if (user == null) {
                return View();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _user.Get(id);

            if (user == null) {
                return View();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            var oldUser = _context.Users.FirstOrDefault(e => e.Id == user.Id);
            if (oldUser != null) {
                user.RoleId = oldUser.RoleId;
                user.AccountId = oldUser.AccountId;
            }

            user.UpdatedDt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.ChangeTracker.Clear();
                _user.Update(user);
                return RedirectToAction("Index", "User");
            }

            foreach (var modelstate in ViewData.ModelState.Values)
            {
                foreach (var modelerror in modelstate.Errors)
                {
                    string errormessage = modelerror.ErrorMessage;
                    ModelState.AddModelError("", errormessage);
                }
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _user.Get(id);
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = _user.Get(id);
            user.UpdatedDt = DateTime.Now;
            user.IsDeleted = true;
            _user.Update(user);

            return RedirectToAction("Index", "User");
        }


    }
}
