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

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var elemanlar = await _context.Eleman
                .Include(b => b.AltBaslik)
                .ToListAsync();
            return View(elemanlar);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silEleman = _context.Eleman.Find(id);
                if (silEleman != null)
                {
                    _context.Eleman.Remove(silEleman);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            //Console.WriteLine("BBBBBBBBBBBB" + id + "CCCCCCCCCCCC" + komut);
            return RedirectToAction("Index");
        }

        /* ───────────── CREATE ───────────── */
        public IActionResult Create()
        {


            return View(_context.AltBaslik.ToList());
        }



        [HttpPost]
        public IActionResult Create(string elemanAdi, string elemanMetin, int altBaslikId)
        {
            //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
            var newEleman = new ElemanClass
            {
                ElemanAdi = elemanAdi,
                ElemanMetin = elemanMetin,
                AltBaslikId = altBaslikId,

            };

            _context.Eleman.Add(newEleman);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */

        public IActionResult Edit(int id)
        {
            var EditEleman = _context.Eleman.Find(id);

            if (EditEleman != null)
            {
                ViewBag.EditEleman = EditEleman;
                return View(_context.AltBaslik.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(ElemanClass EditEleman)
        {


            _context.Eleman.Update(EditEleman);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}