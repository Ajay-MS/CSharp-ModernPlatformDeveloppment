using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NorthwindMvc.Models;
using Packt.Shared;

namespace NorthwindMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private Northwind db;

    public HomeController(ILogger<HomeController> logger, Northwind injectedContext)
    {
        _logger = logger;
        this.db = injectedContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new HomeViewModel
        {
            VisitorCount = (new Random()).Next(1, 1001),
            Categories = db.Categories.ToList(),
            Products = db.Products.ToList(),
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
