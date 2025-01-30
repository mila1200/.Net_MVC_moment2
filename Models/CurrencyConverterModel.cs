using System.ComponentModel.DataAnnotations;

namespace Moment2Mvc.Models;

public class CurrencyConverterModel
{
    [Required(ErrorMessage = "Du måste fylla i en summa att konvertera.")]
    [Display(Name = "Summa:")]
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

    public double ConvertedAmount { get; set; }
}