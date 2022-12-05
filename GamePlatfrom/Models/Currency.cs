
using System.ComponentModel.DataAnnotations;

namespace GamePlatform.Models
{
    public class Currency
    {
        private const decimal TO_USD  = 1.05m;
        private const decimal TO_EURO = 0.95m;
        public enum Code
        {
            USD,
            EUR
        }

        [Required]
        [Range(0, 1000)]
        public decimal MoneyAmount { get;set; }
        
        [Required]
        public string CurrencyCode { get; set; }

        public Currency(decimal money, string code)
        {
            MoneyAmount = money;
            CurrencyCode = code;
        }
        public void ConvertTo(Code code)
        {
            decimal moneyAmount = code.Equals(Code.USD) ?
                                  decimal.Multiply(MoneyAmount, TO_USD) :
                                  decimal.Multiply(MoneyAmount, TO_EURO);

            MoneyAmount = decimal.Round(moneyAmount);
            CurrencyCode = code.ToString();
        }
    }
}