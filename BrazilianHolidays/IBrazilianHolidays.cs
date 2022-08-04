using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrazilianHolidays
{
    internal interface IBrazilianHolidays
    {
        Dictionary<string, string> GetHolidays(string date);
    }
}
