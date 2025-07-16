using Microsoft.AspNetCore.Mvc;
using express_website.Models;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private AppDbContext _context;
        private static List<Blog> _blogs = new(); // geçici liste, veritabanı yerine

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _blogs=_context.Blog.OrderByDescending(b => b.BlogTarih).ToList();

            return View(_blogs);
        }

        public IActionResult Create()
        {
            //var newBlog = new BlogClass();
            return View(/*newBlog*/);
        }

        [HttpPost]
        public IActionResult Create(DateOnly tarih, string baslik, string icerik)
        {
            /*if (!ModelState.IsValid)
                return View(blog);*/

            //blog.Id = _blogs.Count + 1;
            //_blogs.Add(blog);
            var newBlog = new BlogClass{
                BlogBaslik = baslik,
                BlogMetin = icerik,
                BlogTarih = tarih
            };

            _context.Blog.Add(newBlog);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var blog = _blogs.FirstOrDefault(x => x.Id == id);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blog updatedBlog)
        {
            if (!ModelState.IsValid)
                return View(updatedBlog);

            var blog = _blogs.FirstOrDefault(x => x.Id == updatedBlog.Id);
            if (blog == null)
                return NotFound();

            blog.Title = updatedBlog.Title;
            blog.Content = updatedBlog.Content;
            blog.PublishDate = updatedBlog.PublishDate;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blog = _blogs.FirstOrDefault(x => x.Id == id);
            if (blog != null)
                _blogs.Remove(blog);

            return RedirectToAction("Index");
        }
    }
}