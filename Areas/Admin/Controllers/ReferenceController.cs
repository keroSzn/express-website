using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReferenceController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReferenceController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;

            _context = context;
        }

        public IActionResult Index()
        {

            var references = _context.Referans.ToList();
            return View(references);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            Console.WriteLine("BBBBBBBBBBBB" + id);
            var silreferans = _context.Referans.Find(id);
            if (silreferans != null)
            {
                _context.Referans.Remove(silreferans);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var newReferans = new ReferansClass();
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    newReferans.ReferansGorsel = memoryStream.ToArray(); // Görseli byte[] yap ve ata
                }

                _context.Referans.Add(newReferans); // DB'ye nesneyi ekle
                _context.SaveChanges();             // DB'ye işle

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Lütfen bir dosya seçin.";
            return View();
            /*var uploadPath = Path.Combine(_env.WebRootPath, "uploads/references");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            // Burada DB’ye görsel yolu eklenecek (arkadaşınla bağlantı kurulacak)
            // Örn: db.References.Add(new Reference { ImagePath = "/uploads/references/" + fileName });

            return RedirectToAction("Index");*/


        }








    }
}