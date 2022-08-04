using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrazilianHolidays
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("  Informe uma data: ");
            var line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Data inválida, tente novamente");
                line = Console.ReadLine();
            }
            Holiday feriado = new Holiday(line);

            feriado.isHoliday();
        }
    }
}