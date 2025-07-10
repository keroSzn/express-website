using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private static List<Project> _projects = new(); // Geçici liste, DB yerine

        public ProjectController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile image, string description)
        {
            if (image != null && image.Length > 0)
            {
                string uploads = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploads);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string filePath = Path.Combine(uploads, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                _projects.Add(new Project
                {
                    Id = _projects.Count + 1,
                    ImagePath = "/uploads/" + fileName,
                    Description = description
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _projects.FirstOrDefault(p => p.Id == id);
            if (item != null)
                _projects.Remove(item);

            return RedirectToAction("Index");
        }
    }
}