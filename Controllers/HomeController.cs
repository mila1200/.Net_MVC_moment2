using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Moment2Mvc.Models;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {   
        //titel
        @ViewData["Title"] = "Start";
        @ViewBag.Message = "Välj en valuta att konvertera";

        return View();
    }

    [HttpGet("/resultat")]
    public IActionResult Result()
    {
        //titel
        @ViewData["Title"] = "Resultat";

        //hämta jsonsträngen
        var json = HttpContext.Session.GetString("latestResult");

        //om det finns något, omvandla till ett objekt och skicka till vyn
        if (!string.IsNullOrEmpty(json))
        {
            var latestResult = JsonSerializer.Deserialize<CurrencyConverterModel>(json);
            return View(latestResult);
        }

        return View();
    }

    //alternativa sökvägar
    [HttpGet("/historik")]
    public IActionResult History()
    {
        //titel
        @ViewData["Title"] = "Historik";

        //hämtar innehåll och skriver ut det till vyn
        //läs in input
        string jsonStr = System.IO.File.ReadAllText("currency.json");

        //deserialize input
        var currencyConversion = JsonSerializer.Deserialize<List<CurrencyConverterModel>>(jsonStr);
        return View(currencyConversion);
    }

    [HttpPost]
    public IActionResult Index(CurrencyConverterModel model)
    {
        //validera
        if (ModelState.IsValid)
        {
            //korrekt ifyllt
            //beräkna växelvärde
            model.ConvertedAmount = model.Amount * model.ExchangeRate;

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

            //rensa formulär
            ModelState.Clear();

            //sparar senaste input som en json-sträng i en session
            HttpContext.Session.SetString("latestResult", JsonSerializer.Serialize(model));


            //redirectar till /result i controllern Home
            return RedirectToAction("Result", "Home");
        }
        return View();
    }
}
