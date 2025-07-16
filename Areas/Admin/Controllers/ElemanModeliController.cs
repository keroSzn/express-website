using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ElemanModeliController : Controller
    {
        private readonly AppDbContext _context;

        public ElemanModeliController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.ElemanModeli
                .Include(em => em.AitOlduguEleman)
                .ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Elemanlar = _context.Eleman.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElemanModeliClass elemanModeli)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Elemanlar = _context.Eleman.ToList();
                return View(elemanModeli);
            }

            _context.ElemanModeli.Add(elemanModeli);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = _context.ElemanModeli.FirstOrDefault(x => x.ElemanModeliId == id);
            if (model == null) return NotFound();

            ViewBag.Elemanlar = _context.Eleman.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ElemanModeliClass updated)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Elemanlar = _context.Eleman.ToList();
                return View(updated);
            }

            var model = _context.ElemanModeli.FirstOrDefault(x => x.ElemanModeliId == updated.ElemanModeliId);
            if (model == null) return NotFound();

            model.ElemanModeliAdi = updated.ElemanModeliAdi;
            model.FiyatBilgisi1 = updated.FiyatBilgisi1;
            model.FiyatBilgisi2 = updated.FiyatBilgisi2;
            model.ElemanId = updated.ElemanId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _context.ElemanModeli.FirstOrDefault(x => x.ElemanModeliId == id);
            if (model == null) return NotFound();

            _context.ElemanModeli.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}