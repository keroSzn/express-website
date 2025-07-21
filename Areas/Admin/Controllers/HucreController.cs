using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using express_website.Models;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HucreController : Controller
    {
        private readonly AppDbContext _context;

        public HucreController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var hucreler = await _context.Hucre
                .Include(b => b.Alan)
                .ToListAsync();
            return View(hucreler);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silHucre = _context.Hucre.Find(id);
                if (silHucre != null)
                {
                    _context.Hucre.Remove(silHucre);
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


            return View(_context.Alan.ToList());
        }



        [HttpPost]
        public IActionResult Create(string hucreMetin, int alanId)
        {
            //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
            var newHucre = new HucreClass
            {
                HucreMetin = hucreMetin,
                AlanId = alanId,

            };

            _context.Hucre.Add(newHucre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */

        public IActionResult Edit(int id)
        {
            var EditHucre = _context.Hucre.Find(id);

            if (EditHucre != null)
            {
                ViewBag.EditHucre = EditHucre;
                return View(_context.Alan.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(HucreClass EditHucre)
        {


            _context.Hucre.Update(EditHucre);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}