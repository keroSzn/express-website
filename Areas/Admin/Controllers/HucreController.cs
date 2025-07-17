using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HucreController : Controller
    {
        private readonly AppDbContext _context;

        public HucreController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hucreler = _context.Hucre
                .Include(h => h.Alan)
                .ToList();
            return View(hucreler);
        }

        public IActionResult Create()
        {
            ViewBag.Alanlar = _context.Alan.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HucreClass hucre)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alanlar = _context.Alan.ToList();
                return View(hucre);
            }

            _context.Hucre.Add(hucre);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var hucre = _context.Hucre.FirstOrDefault(h => h.HucreId == id);
            if (hucre == null) return NotFound();

            ViewBag.Alanlar = _context.Alan.ToList();
            return View(hucre);
        }

        [HttpPost]
        public IActionResult Edit(HucreClass updated)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alanlar = _context.Alan.ToList();
                return View(updated);
            }

            var hucre = _context.Hucre.FirstOrDefault(h => h.HucreId == updated.HucreId);
            if (hucre == null) return NotFound();

            hucre.HucreMetin = updated.HucreMetin;
            hucre.AlanId = updated.AlanId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var hucre = _context.Hucre.FirstOrDefault(h => h.HucreId == id);
            if (hucre == null) return NotFound();

            _context.Hucre.Remove(hucre);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}