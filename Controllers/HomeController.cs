using System.Text.Json;
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
        //hämtar innehåll och skriver ut det till vyn
        //läs in input
        string jsonStr = System.IO.File.ReadAllText("currency.json");

        //deserialize input
        var currencyConversion = JsonSerializer.Deserialize<List<CurrencyConverterModel>>(jsonStr);
        return View(currencyConversion);
    }

    //alternativa sökvägar
    [HttpGet("/historik")]
    public IActionResult History()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CurrencyConverterModel model)
    {
        //validera
        if (ModelState.IsValid)
        {
            //korrekt ifyllt
            //läs in input
            string jsonStr = System.IO.File.ReadAllText("currency.json");

            //deserialize input
            var currencyConversion = JsonSerializer.Deserialize<List<CurrencyConverterModel>>(jsonStr);

            //lägg till
            if (currencyConversion != null)
            {
                currencyConversion.Add(model);

                //serialize json
                jsonStr = JsonSerializer.Serialize(currencyConversion);

                //lägg till ändringar
                System.IO.File.WriteAllText("currency.json", jsonStr);
            }

            ModelState.Clear();

            //redirectar till /result i controllern Home
            return RedirectToAction("Result", "Home");
        }
        return View();
    }
}
