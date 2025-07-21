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

        public IActionResult Details(int id)
        {
            var iletisim = _context.Iletisim.FirstOrDefault(i => i.IletisimId == id);
            if (iletisim == null)
                return NotFound();

            return View(iletisim);
        }
    }
}