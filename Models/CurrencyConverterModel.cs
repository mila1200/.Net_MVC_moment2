using System.ComponentModel.DataAnnotations;

namespace Moment2Mvc.Models;

public class CurrencyConverterModel
{
    [Required(ErrorMessage = "Du måste fylla i en summa att konvertera.")]
    //Beloppet måste vara över 0
    [Range(0.01, double.MaxValue, ErrorMessage ="Beloppet kan inte vara under 0.")]
    [Display(Name = "Belopp:")]
    //? istället för required eftersom Amount annars blir 0 och inte null vid tomt fält och då fungerar ej required med felmeddelande
    public double? Amount { get; set; }

    //Inget felmeddelande då alternativet är förifyllt
    [Required]
    [Display(Name = "Från:")]
    public required string FromCurrency { get; set; }

    //Inget felmeddelande då alternativet är förifyllt
    [Required]
    [Display(Name = "Till:")]
    public required string ToCurrency { get; set; }

    //? istället för required eftersom Amount annars blir 0 och inte null vid tomt fält och då fungerar ej required med felmeddelande
    [Required(ErrorMessage = "Du måste fylla i växelkurs för att konvertera.")]
    //inget negativt värde
    [Range(0.01, double.MaxValue, ErrorMessage ="Växelkursen kan inte vara under 0.")]
    [Display(Name = "Växelkurs:")]
    public double? ExchangeRate { get; set; }

    public double? ConvertedAmount { get; set; }
}