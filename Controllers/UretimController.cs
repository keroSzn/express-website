using express_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace express_website.Controllers;

public class UretimController : Controller
{
    private readonly ILogger<UretimController> _logger;

    public UretimController(ILogger<UretimController> logger)
    {
        _logger = logger;
    }

    public IActionResult Uretim()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
