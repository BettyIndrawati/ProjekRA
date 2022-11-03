using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;
using RAS.Bootcamp.RumahAqiqah.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RAS.Bootcamp.RumahAqiqah.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        public AccountController(ILogger<AccountController> logger, ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Roles"] = new SelectList(_dbcontext.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest register)
        {
            var newAccount = new Account
            {
                Username = register.Username,
                Password = register.Password,
                LastLogin = DateTime.Now,
                CreatedBy = 1,
                UpdatedBy = 1,
             
            };
            newAccount.LastLogin = DateTime.Now;
            newAccount.CreatedDt = DateTime.Now;
            newAccount.UpdatedDt = DateTime.Now;
            newAccount.IsDeleted = false;

            ViewData["Roles"] = new SelectList(_dbcontext.Roles, "Id", "Name");

            var newUser = new User
            {
                RoleId = (int)register.RoleId,
                AccountId = newAccount.Id,
                ReferalCode = register.ReferalCode,
                Name = register.Name,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                Account = newAccount,
                CreatedBy = 1,
                UpdatedBy = 1,
            };
            newUser.CreatedDt = DateTime.Now;
            newUser.UpdatedDt = DateTime.Now;
            newUser.IsDeleted = false;
            _dbcontext.Accounts.Add(newAccount);
            _dbcontext.Users.Add(newUser);
            _dbcontext.SaveChanges();

            var newUserProfile = new UserProfile
            {
                UserId = newUser.Id,
                PoB = register.PoB,
                DoB = register.DoB,
                Address = register.Address,
                IdentityNumber = register.IdentityNumber,
                RT = register.RT,
                RW = register.RW,
                District = register.District,
                City = register.City,
                CreatedBy = 1,
                UpdatedBy = 1,
            };
            newUserProfile.CreatedDt = DateTime.Now;
            newUserProfile.UpdatedDt = DateTime.Now;
            newUserProfile.IsDeleted = false;

            _dbcontext.UserProfiles.Add(newUserProfile);
            _dbcontext.SaveChanges();
             return RedirectToAction("Index", "Home");
        }

    public IActionResult Login() {
        return View(new LoginRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request) {
        if(!ModelState.IsValid){
            return View(request);
        }


        var akun = _dbcontext.Accounts
        .FirstOrDefault(x=>x.Username == request.Username && x.Password == request.Password);

        if(akun == null){
            ViewBag.ErrorMessage = "Invalid username or password";

            return View(request);
        }
        akun.LastLogin = DateTime.Now;
        akun.UpdatedDt = DateTime.Now;
        _dbcontext.SaveChanges();
        
        //Set Authorization data to cookies
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, akun.Id.ToString()),
            new Claim(ClaimTypes.Name, akun.Username),
            new Claim("FullName", akun.Username),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity), 
            authProperties);

        
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}