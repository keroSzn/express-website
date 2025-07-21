using Microsoft.AspNetCore.Mvc;
using express_website.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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

        [HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 1)
            {
                //silme
                var silblog = _context.Blog.Find(id);
                if (silblog != null)
                {
                    _context.Blog.Remove(silblog);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            Console.WriteLine("BBBBBBBBBBBB" + id + "CCCCCCCCCCCC" + komut);
            return RedirectToAction("Index");
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
            var Editblog = _context.Blog.Find(id);

            if (Editblog != null)
            {

                return View(Editblog);
            }
            return View();
        }



        [HttpPost]
        public IActionResult Edit(BlogClass blog)
        {


            _context.Blog.Update(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}