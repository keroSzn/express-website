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

        /*[HttpPost]
        public IActionResult Index(int id, int komut)
        {
            if (komut == 0)
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
            if (komut == 1)
            {
                //düzenleme
                var Editblog = _context.Blog.Find(id);
                if (Editblog != null)
                {
                    /*_context.Blog.Update(editblog);
                    _context.SaveChanges();*/
                    /*return View("Edit", Editblog);
                }
            }
            Console.WriteLine("BBBBBBBBBBBB" + id+ "CCCCCCCCCCCC" +komut);
            /*var silreferans = _context.Referans.Find(id);
            if (silreferans != null)
            {
                _context.Referans.Remove(silreferans);
                _context.SaveChanges();
            }*/

            /*return RedirectToAction("Index");
        }*/

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

        public IActionResult Edit(int blogId)
        {
            var Editblog = _context.Blog.Find(blogId);
            
                if (Editblog != null)
            {
                /*_context.Blog.Update(editblog);
                _context.SaveChanges();*/


                return View(Editblog);
            }
            return View();
        }

        

        [HttpPost]
        public IActionResult Edit(BlogClass blog)
        {
              /*
              int blogId, DateOnly blogTarih, string blogBaslik, string blogMetin
              */  
            
            _context.Blog.Update(blog);
            _context.SaveChanges();
            /*var blog = _context.Blog.Find(blogId);
            if (blog == null)
                return NotFound();
*/
            return RedirectToAction("Index");
        }

        /*[HttpPost]
        
        public IActionResult EditApprove(BlogClass updatedBlog)
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
        }*@

        @*public IActionResult Delete(int id)
        {
            var blog = _context.Blog.FirstOrDefault(b => b.BlogId == id);
            if (blog == null)
                return NotFound();

            _context.Blog.Remove(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }*/
    }
}