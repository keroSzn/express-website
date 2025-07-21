using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AltBaslikController : Controller
    {
        private readonly AppDbContext _context;

        public AltBaslikController(AppDbContext context)
        {
            _context = context;
        }

        /* ───────────── LIST ───────────── */
        public async Task<IActionResult> Index()
        {
            var altBasliklar = await _context.AltBaslik
                .Include(b => b.Baslik)
                .ToListAsync();
            return View(altBasliklar);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silAltBaslik = _context.AltBaslik.Find(id);
                if (silAltBaslik != null)
                {
                    _context.AltBaslik.Remove(silAltBaslik);
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


            return View(_context.Baslik.ToList());
        }



        [HttpPost]
        public IActionResult Create(string altBaslikAdi, int baslikId)
        {
            //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + kategoriId);
            var newAltBaslik = new AltBaslikClass
            {
                AltBaslikAdi = altBaslikAdi,
                BaslikId = baslikId,

            };

            _context.AltBaslik.Add(newAltBaslik);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* ───────────── EDIT ───────────── */

        public IActionResult Edit(int id)
        {
            var EditAltBaslik = _context.AltBaslik.Find(id);

            if (EditAltBaslik != null)
            {
                ViewBag.EditAltBaslik = EditAltBaslik;
                return View(_context.Baslik.ToList());
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(AltBaslikClass EditAltBaslik)
        {


            _context.AltBaslik.Update(EditAltBaslik);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}