using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaslikController : Controller
    {
        private readonly AppDbContext _context;

        public BaslikController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var basliklar = await _context.Baslik
                .Include(b => b.Kategori)
                .ToListAsync();
            return View(basliklar);
        }

        /* ───────────── CREATE ───────────── */
        public IActionResult Create()
        {
            /*ViewBag.KategoriList = _context.Kategori
                .Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = k.KategoriId.ToString(),
                    Text = k.KategoriAdi
                }).ToList();
            return View();*/

            //var KategoriList = new List<KategoriClass>();

            return View(_context.Kategori.ToList());
        }

        /*[HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string baslikAdi, int kategoriId)
        {
            
                var newBaslik = new BaslikClass
                {
                    BaslikAdi = baslikAdi,
                    KategoriId = kategoriId,
                    
                };

                _context.Baslik.Add(newBaslik);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
            
            /*ViewBag.KategoriList = _context.Kategori
                .Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = k.KategoriId.ToString(),
                    Text = k.KategoriAdi
                }).ToList();
            return View(newBaslik);
        }*/

        [HttpPost]
        public IActionResult Create(string baslikAdi, int kategoriId)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"+kategoriId);
            var newBaslik = new BaslikClass
            {
                BaslikAdi = baslikAdi,
                KategoriId = kategoriId,
                
            };

            _context.Baslik.Add(newBaslik);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var baslik = await _context.Baslik.FindAsync(id);
            if (baslik == null) return NotFound();

            ViewBag.KategoriList = _context.Kategori
                .Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = k.KategoriId.ToString(),
                    Text = k.KategoriAdi
                }).ToList();

            return View(baslik);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BaslikClass baslik)
        {
            if (id != baslik.BaslikId) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewBag.KategoriList = _context.Kategori
                    .Select(k => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = k.KategoriId.ToString(),
                        Text = k.KategoriAdi
                    }).ToList();
                return View(baslik);
            }

            _context.Update(baslik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /* ───────────── DELETE ───────────── */
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var baslik = await _context.Baslik
                .Include(b => b.Kategori)
                .FirstOrDefaultAsync(m => m.BaslikId == id);
            if (baslik == null) return NotFound();
            return View(baslik);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baslik = await _context.Baslik.FindAsync(id);
            if (baslik != null)
            {
                _context.Baslik.Remove(baslik);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}