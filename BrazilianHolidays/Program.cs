using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installments
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("  Informe a data da primeira parcela: ");
            var line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Data inválida, tente novamente");
                line = Console.ReadLine();
            }
            Installments feriado = new Installments(line);

            feriado.twelveInstallments();
        }
    }
}