using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class IletisimController : Controller
    {
        private readonly AppDbContext _context;

        public IletisimController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var iletisimler = _context.Iletisim.ToList();
            return View(iletisimler);
        }

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silIletisim = _context.Iletisim.Find(id);
                if (silIletisim != null)
                {
                    _context.Iletisim.Remove(silIletisim);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            //Console.WriteLine("BBBBBBBBBBBB" + id + "CCCCCCCCCCCC" + komut);
            return RedirectToAction("Index");
        }

        
    }
}