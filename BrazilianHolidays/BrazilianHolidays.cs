using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installments
{
    internal class BrazilianHolidays : IBrazilianHolidays
    {
        private string carnival = "";
        private string goodFriday = "";
        private string corpusChristi = "";
        
        public IReadOnlyDictionary<string, string> GetHolidays(string date)
        {
            var year = Convert.ToInt32(date.Split("/")[2]);

            Dictionary<string, string> result = new Dictionary<string, string>();

            EasterDateCalculator calculadoraDataPascoa = new EasterDateCalculator(year);

            var easterFullDate = calculadoraDataPascoa.calculateEasterDate();

            // holidays correlated with Easter
            carnival = easterFullDate.AddDays(-47).ToString("dd/MM");
            goodFriday = easterFullDate.AddDays(-2).ToString("dd/MM");
            corpusChristi = easterFullDate.AddDays(60).ToString("dd/MM");

            result.Add("01/01", "Confraternização Universal");
            result.Add(carnival, "Carnaval");
            result.Add(goodFriday, "Sexta-feira Santa");
            result.Add(easterFullDate.ToString("dd/MM"), "Páscoa");
            result.Add("21/04", "Tiradentes");
            result.Add("01/05", "Dia Mundial do Trabalho");
            result.Add(corpusChristi, "Corpus Christi");
            result.Add("07/09", "Independência do Brasil");
            result.Add("12/10", "Nossa Senhora Aparecida");
            result.Add("02/11", "Finados");
            result.Add("15/11", "Proclamação da República");
            result.Add("25/12", "Natal");

            return result;
        }
    }
}
