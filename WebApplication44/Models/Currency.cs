using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication44.Models
{
    public class Currency : IConvertableCurrency
    {
        enum Code
        {
            USD,
            EUR
        }
        private const decimal DEFAULT_MONEY_AMOUNT = 0;
        private decimal _moneyAmount;
        private string _currencyCode;

        public decimal MoneyAmount
        {
            get
            {
                return _moneyAmount;
            }
            set
            {
                _moneyAmount = value < 0 ? DEFAULT_MONEY_AMOUNT : value;
            }
        }

        public string CurrencyCode 
        {
            get
            {
                return _currencyCode;
            }
            set
            {
                if(value == null)
                {
                    return;
                }
                if (value.Equals(Code.EUR.ToString()) || 
                    value.Equals(Code.USD.ToString()))
                {
                    _currencyCode = value;
                }
                else
                {
                    _currencyCode = Code.EUR.ToString();
                }
            } 
        }
     
        public Currency(decimal money, string code)
        {
            MoneyAmount = money;
            CurrencyCode = code;
        }
        public override string ToString()
        {
            return CurrencyCode + " " + MoneyAmount;
        }

        public void ConvertToUSD()
        {
            if (CurrencyCode.Equals(Code.EUR.ToString()))
            {
                MoneyAmount = decimal.Multiply(MoneyAmount, (decimal)1.04);
                CurrencyCode = Code.USD.ToString();
            }
        }

        public void ConvertToEURO()
        {
            if (CurrencyCode.Equals(Code.USD.ToString()))
            {
                MoneyAmount = decimal.Multiply(MoneyAmount, (decimal)0.96);
                CurrencyCode = Code.EUR.ToString();
            }
        }
    }
}