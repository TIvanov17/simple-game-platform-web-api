using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication44.Models
{
    interface IConvertableCurrency
    {
        void ConvertToUSD();
        void ConvertToEURO();
    }
}
