using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using express_website.Models;

namespace express_website.Controllers;

public class CozumController : Controller
{
    private readonly ILogger<CozumController> _logger;

    public CozumController(ILogger<CozumController> logger)
    {
        _logger = logger;
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
}
