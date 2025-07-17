using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using System.Linq;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blog.OrderByDescending(b => b.BlogTarih).ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DateOnly tarih, string baslik, string icerik)
        {
            var newBlog = new BlogClass
            {
                BlogTarih = tarih,
                BlogBaslik = baslik,
                BlogMetin = icerik
            };

            _context.Blog.Add(newBlog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var blog = _context.Blog.FirstOrDefault(b => b.BlogId == id);
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(BlogClass updatedBlog)
        {
            if (!ModelState.IsValid)
                return View(updatedBlog);

            var blog = _context.Blog.FirstOrDefault(b => b.BlogId == updatedBlog.BlogId);
            if (blog == null)
                return NotFound();

            blog.BlogTarih = updatedBlog.BlogTarih;
            blog.BlogBaslik = updatedBlog.BlogBaslik;
            blog.BlogMetin = updatedBlog.BlogMetin;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blog = _context.Blog.FirstOrDefault(b => b.BlogId == id);
            if (blog == null)
                return NotFound();

            _context.Blog.Remove(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}