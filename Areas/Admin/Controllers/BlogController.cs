using Microsoft.AspNetCore.Mvc;


namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private static List<Blog> _blogs = new(); // geçici liste, veritabanı yerine

        public IActionResult Index()
        {
            return View(_blogs.OrderByDescending(x => x.PublishDate).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (!ModelState.IsValid)
                return View(blog);

            blog.Id = _blogs.Count + 1;
            _blogs.Add(blog);
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