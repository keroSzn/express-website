using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HakkimizdaController : Controller
    {
        private readonly AppDbContext _context;

        public HakkimizdaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Hakkimizda.Find(1));
        }

        public IActionResult Edit()
        { 
            return View(_context.Hakkimizda.Find(1));
        }



        [HttpPost]
        public IActionResult Edit(HakkimizdaClass hakkimizda)
        {


            _context.Hakkimizda.Update(hakkimizda);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}