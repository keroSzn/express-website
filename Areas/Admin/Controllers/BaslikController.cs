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

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silBaslik = _context.Baslik.Find(id);
                if (silBaslik != null)
                {
                    if (_context.AltBaslik.Any(x => x.BaslikId == id))
                    {
                        TempData["BaslikSilmeHata"] = "Bu başlığa bağlı alt başlıklar var. Önce onları silmelisiniz.";
                        return RedirectToAction("Index");
                    }
                    _context.Baslik.Remove(silBaslik);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }

            //Console.WriteLine("BBBBBBBBBBBB" + id + "CCCCCCCCCCCC" + komut);
            return RedirectToAction("Index");
        }

        /* ───────────── CREATE ───────────── */
        public IActionResult Create()
        {


            return View(_context.Kategori.ToList());
        }



        [HttpPost]
        public IActionResult Create(string baslikAdi, int kategoriId)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
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

        public IActionResult Edit(int id)
        {
            var EditBaslik = _context.Baslik.Find(id);

            if (EditBaslik != null)
            {
                ViewBag.EditBaslik = EditBaslik;
                return View(_context.Kategori.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(BaslikClass EditBaslik)
        {


            _context.Baslik.Update(EditBaslik);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}