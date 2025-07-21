using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AlanController : Controller
    {
        private readonly AppDbContext _context;

        public AlanController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var alanlar = await _context.Alan
                .Include(b => b.ElemanModeli)
                .ToListAsync();
            return View(alanlar);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silAlan = _context.Alan.Find(id);
                if (silAlan != null)
                {
                    _context.Alan.Remove(silAlan);
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


            return View(_context.ElemanModeli.ToList());
        }



        [HttpPost]
        public IActionResult Create(string alanAdi, int elemanModeliId)
        {
            //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
            var newAlan = new AlanClass
            {
                AlanAdi = alanAdi,
                ElemanModeliId = elemanModeliId,

            };

            _context.Alan.Add(newAlan);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */

        public IActionResult Edit(int id)
        {
            var EditAlan = _context.Alan.Find(id);

            if (EditAlan != null)
            {
                ViewBag.EditAlan = EditAlan;
                return View(_context.ElemanModeli.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(AlanClass EditAlan)
        {


            _context.Alan.Update(EditAlan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}