using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ElemanModeliController : Controller
    {
        private readonly AppDbContext _context;

        public ElemanModeliController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var elemanModelleri = await _context.ElemanModeli
                .Include(b => b.Eleman)
                .ToListAsync();
            return View(elemanModelleri);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silElemanModeli = _context.ElemanModeli.Find(id);
                if (silElemanModeli != null)
                {
                    if (_context.Alan.Any(x => x.ElemanModeliId == id))
                    {
                        TempData["ElemanModeliSilmeHata"] = "Bu eleman modeline bağlı alanlar var. Önce onları silmelisiniz.";
                        return RedirectToAction("Index");
                    }
                    _context.ElemanModeli.Remove(silElemanModeli);
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


            return View(_context.Eleman.ToList());
        }



        [HttpPost]
        public IActionResult Create(string elemanModeliAdi, int? fiyatBilgisi1, int? fiyatBilgisi2, int elemanId)
        {
            //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
            var newElemanModeli = new ElemanModeliClass
            {
                ElemanModeliAdi = elemanModeliAdi,
                FiyatBilgisi1 = fiyatBilgisi1,
                FiyatBilgisi2 = fiyatBilgisi2,
                ElemanId = elemanId,

            };

            _context.ElemanModeli.Add(newElemanModeli);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */

        public IActionResult Edit(int id)
        {
            var EditElemanModeli = _context.ElemanModeli.Find(id);

            if (EditElemanModeli != null)
            {
                ViewBag.EditElemanModeli = EditElemanModeli;
                return View(_context.Eleman.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(ElemanModeliClass EditElemanModeli)
        {


            _context.ElemanModeli.Update(EditElemanModeli);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}