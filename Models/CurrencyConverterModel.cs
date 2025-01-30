using System.ComponentModel.DataAnnotations;

namespace Moment2Mvc.Models;

public class CurrencyConverterModel {
    
    [Required]
    public required decimal Amount { get; set; }

     [Required]
    public required string FromCurrency { get; set; }

     [Required]
    public required string ToCurrency { get; set; }

    public decimal ConvertedAmount { get; set; }
}