using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using express_website.Models;

namespace express_website.Controllers;

public class HomeController : Controller
{
    private AppDbContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;

        _context = context;
    }

    public IActionResult Index()
    {
        var viewModel = new HomePageViewModel
        {
            HakkimizdaList = _context.Hakkimizda.ToList(),
            Projeler = _context.Proje.ToList(),
            Blog = _context.Blog.ToList(),
            Referanslar = _context.Referans.ToList(),
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Uretim()
    {
        return View();
    }
    public IActionResult Cozum()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult Iletisim(string name, string email, string subject, string message)
    {
        var newIletisim = new IletisimClass
        {
            IletisimAdSoyad = name,
            IletisimMail = email,
            IletisimKonu = subject,
            IletisimMesaj=message
        };

        _context.Iletisim.Add(newIletisim);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
