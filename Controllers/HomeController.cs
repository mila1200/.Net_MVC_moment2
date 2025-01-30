using Microsoft.AspNetCore.Mvc;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    //alternativa sökvägar
    [HttpGet("/resultat")]
    public IActionResult Result()
    {
        return View();
    }

    //alternativa sökvägar
    [HttpGet("/historik")]
    public IActionResult History()
    {
        return View();
    }
}
