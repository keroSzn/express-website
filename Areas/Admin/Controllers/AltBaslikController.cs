using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using Microsoft.EntityFrameworkCore;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AltBaslikController : Controller
    {
        private readonly AppDbContext _context;

        public AltBaslikController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var altbasliklar = _context.AltBaslik
                .Include(x => x.Baslik)
                .OrderByDescending(x => x.AltBaslikId)
                .ToList();
            return View(altbasliklar);
        }

        public IActionResult Create()
        {
            ViewBag.Basliklar = _context.Baslik.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AltBaslikClass altBaslik)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Basliklar = _context.Baslik.ToList();
                return View(altBaslik);
            }

            _context.AltBaslik.Add(altBaslik);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var altBaslik = _context.AltBaslik.FirstOrDefault(x => x.AltBaslikId == id);
            if (altBaslik == null)
                return NotFound();

            ViewBag.Basliklar = _context.Baslik.ToList();
            return View(altBaslik);
        }

        [HttpPost]
        public IActionResult Edit(AltBaslikClass altBaslik)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Basliklar = _context.Baslik.ToList();
                return View(altBaslik);
            }

            var original = _context.AltBaslik.FirstOrDefault(x => x.AltBaslikId == altBaslik.AltBaslikId);
            if (original == null)
                return NotFound();

            original.AltBaslikAdi = altBaslik.AltBaslikAdi;
            original.BaslikId = altBaslik.BaslikId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var altBaslik = _context.AltBaslik.FirstOrDefault(x => x.AltBaslikId == id);
            if (altBaslik != null)
            {
                _context.AltBaslik.Remove(altBaslik);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}