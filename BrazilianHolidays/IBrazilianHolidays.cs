using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installments
{
    internal interface IBrazilianHolidays
    {
        IReadOnlyDictionary<string, string> GetHolidays(string date);
    }
}
