using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ElemanController : Controller
    {
        private readonly AppDbContext _context;

        public ElemanController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var elemanlar = _context.Eleman
                .Include(e => e.AltBaslik)
                .ToList();
            return View(elemanlar);
        }

        public IActionResult Create()
        {
            ViewBag.AltBasliklar = _context.AltBaslik.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElemanClass eleman)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AltBasliklar = _context.AltBaslik.ToList();
                return View(eleman);
            }

            _context.Eleman.Add(eleman);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var eleman = _context.Eleman.FirstOrDefault(e => e.ElemanId == id);
            if (eleman == null) return NotFound();

            ViewBag.AltBasliklar = _context.AltBaslik.ToList();
            return View(eleman);
        }

        [HttpPost]
        public IActionResult Edit(ElemanClass updated)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AltBasliklar = _context.AltBaslik.ToList();
                return View(updated);
            }

            var eleman = _context.Eleman.FirstOrDefault(e => e.ElemanId == updated.ElemanId);
            if (eleman == null) return NotFound();

            eleman.ElemanAdi = updated.ElemanAdi;
            eleman.ElemanMetin = updated.ElemanMetin;
            eleman.AltBaslikId = updated.AltBaslikId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var eleman = _context.Eleman.FirstOrDefault(e => e.ElemanId == id);
            if (eleman == null) return NotFound();

            _context.Eleman.Remove(eleman);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}