using Microsoft.AspNetCore.Mvc;
using Moment2Mvc.Models;

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

    [HttpPost]
    public IActionResult Result(CurrencyConverterModel model) {
        //validera
        if(ModelState.IsValid) {

        } else {
            //fel
        }
        return View();
    }
}
