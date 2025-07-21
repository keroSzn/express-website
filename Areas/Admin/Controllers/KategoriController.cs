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

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silKategori = _context.Kategori.Find(id);
                if (silKategori != null)
                {
                    _context.Kategori.Remove(silKategori);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            Console.WriteLine("BBBBBBBBBBBB" + id + "CCCCCCCCCCCC" + komut);
            return RedirectToAction("Index");
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
        public IActionResult Edit(int id)
        {
            var EditKategori = _context.Kategori.Find(id);

            if (EditKategori != null)
            {

                return View(EditKategori);
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(KategoriClass kategori)
        {


            _context.Kategori.Update(kategori);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /**/

    }
}