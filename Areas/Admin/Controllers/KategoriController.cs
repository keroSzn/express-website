using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class KategoriController : Controller
    {
        private readonly AppDbContext _context;

        public KategoriController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var kategoriler = await _context.Kategori
                                            .Include(k => k.BaslikListe)
                                            .ToListAsync();
            return View(kategoriler);
        }

        /* ───────────── CREATE ───────────── */
        public IActionResult Create()
        {
            //var newKategori = new KategoriClass();
            return View();
        }


        [HttpPost]
        public IActionResult Create(string kategoriAdi, string kategoriMetin)
        {
            var newKategori = new KategoriClass
            {
                KategoriAdi = kategoriAdi,
                KategoriMetin = kategoriMetin
            };

            _context.Kategori.Add(newKategori);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var kategori = await _context.Kategori.FindAsync(id);
            if (kategori == null) return NotFound();

            return View(kategori);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KategoriClass kategori)
        {
            if (id != kategori.KategoriId) return NotFound();
            if (!ModelState.IsValid) return View(kategori);

            try
            {
                _context.Update(kategori);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Kategori.Any(e => e.KategoriId == id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        /* ───────────── DELETE ───────────── */
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kategori = await _context.Kategori
                                         .FirstOrDefaultAsync(m => m.KategoriId == id);
            if (kategori == null) return NotFound();

            return View(kategori);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _context.Kategori.FindAsync(id);
            if (kategori != null)
            {
                _context.Kategori.Remove(kategori);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}