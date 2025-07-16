using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlanController : Controller
    {
        private readonly AppDbContext _context;

        public AlanController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var alanlar = _context.Alan
                .Include(a => a.AitOlduguElemanModeli)
                .ToList();
            return View(alanlar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlanClass alan)
        {
            if (!ModelState.IsValid)
                return View(alan);

            _context.Alan.Add(alan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var alan = _context.Alan.FirstOrDefault(a => a.AlanId == id);
            if (alan == null)
                return NotFound();

            return View(alan);
        }

        [HttpPost]
        public IActionResult Edit(AlanClass updated)
        {
            if (!ModelState.IsValid)
                return View(updated);

            var alan = _context.Alan.FirstOrDefault(a => a.AlanId == updated.AlanId);
            if (alan == null)
                return NotFound();

            alan.AlanAdi = updated.AlanAdi;
            alan.ModelId = updated.ModelId;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var alan = _context.Alan.FirstOrDefault(a => a.AlanId == id);
            if (alan == null)
                return NotFound();

            _context.Alan.Remove(alan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}