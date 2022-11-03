using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

namespace RAS.Bootcamp.RumahAqiqah.Cms.Controllers
{
    public class PromoController : Controller
    {
        private readonly IRepository<Promo> _promo;
        private readonly ApplicationDbContext _dbcontext;

        public PromoController(ApplicationDbContext context, IRepository<Promo> Promo)
        {
            _dbcontext = context;
            _promo = Promo;
        }

        public IActionResult Index()
        {
            var datapromo = _dbcontext.Promos.ToList();
            return View(datapromo);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(RequestPromo req)
        {
        var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Promo");
        var filename = $"{req.Code}-{req.Banner.FileName}";
        var filepath = Path.Combine(folder,filename);
        using var stream = System.IO.File.Create(filepath);
        if (req.Banner != null){
            req.Banner.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Promo/{filename}"; 
            
            var idakun= int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
            var pr = new Promo{
                Code = req.Code,
                StartDate = req.StartDate,
                EndDate= req.EndDate,
                Quota= req.Quota,
                PromoType = (PromoType)req.tipe,
                Value = req.Value,
                Banner = filename,
                url = url,
                CreatedBy = idakun,
                CreatedDt= DateTime.Now,
            };
            _promo.Add(pr);

            var allpromo = _promo.GetList;
            return View("index",allpromo);
        }

        public IActionResult Update(int id)
        {
            var pr = _promo.Get(id);
            var requpdate = new RequestPromo{
                Code = pr.Code,
                StartDate = pr.StartDate,
                EndDate = pr.EndDate,
                Quota = pr.Quota,
                tipe = (int)pr.PromoType,
                url = pr.url,
                Id = id
            };
            return View(requpdate);
        }

        [HttpPost]
        public IActionResult Update(RequestPromo req)
        {
            //Ngurus Input data baru
        var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images");
        var filename = $"{req.Code}-{req.Banner.FileName}";
        var filepath = Path.Combine(folder,filename);
        using var stream = System.IO.File.Create(filepath);
        if (req.Banner != null){
            req.Banner.CopyTo(stream);
        }
        var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";    
        
        // Perubahan Data ke database
        Promo updated = _promo.Get(req.Id);
        var Deletedfilepath = Path.Combine(folder,updated.Banner);
        System.IO.File.Delete(Deletedfilepath);

        var idakun= int.Parse(User.Claims.First(e=> e.Type == "ID").Value);
        updated.Code = req.Code;
        updated.StartDate = req.StartDate;
        updated.EndDate= req.EndDate;
        updated.Quota= req.Quota;
        updated.PromoType = (PromoType)req.tipe;
        updated.Value = req.Value;
        updated.Banner = filename;
        updated.url = url;
        updated.CreatedBy = idakun;
        updated.CreatedDt= DateTime.Now;

        var datapromo = _promo.GetList;
        return View("Index",datapromo);

        }
        public IActionResult Delete(int id)
        {
            _promo.Remove(id);
            var pr = _promo.GetList;
            return View("Index",pr);
        }
    }
}