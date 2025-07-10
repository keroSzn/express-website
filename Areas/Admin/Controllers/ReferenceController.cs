using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReferenceController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ReferenceController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            // Sahte veriler (database bağlanınca yerine geçecek)
            var references = new List<string>();

            var path = Path.Combine(_env.WebRootPath, "uploads/references");
            if (Directory.Exists(path))
            {
                references = Directory.GetFiles(path)
                                    .Select(Path.GetFileName)
                                    .Where(name => name != null)
                                    .Select(name => name!)
                                    .ToList();
            }

            return View(references);
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
                var uploadPath = Path.Combine(_env.WebRootPath, "uploads/references");
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

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Lütfen bir dosya seçin.";
            return View();
        }

        public IActionResult Delete(string fileName)
        {
            var fullPath = Path.Combine(_env.WebRootPath, "uploads/references", fileName);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

            
            return RedirectToAction("Index");
        }
    }
}