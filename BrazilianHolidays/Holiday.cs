using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrazilianHolidays
{
    public class Holiday
    {
        private string date;

        public Holiday(string date)
        {
            this.date = date;
        }
        public string Date
        {
            get { return date; }
        }

        public void isHoliday()
        {
            IBrazilianHolidays brazilianHolidays = new BrazilianHolidays();
            var holidayList = brazilianHolidays.GetHolidays(date);

            var daysMonth = date.Substring(0, 5);

            if (holidayList.ContainsKey(daysMonth))
            {
                var index = holidayList.Keys.ToList().IndexOf(daysMonth);
                var length = 27 - holidayList.Values.ToList()[index].Length;
                var aux = length % 2 == 0 ? "" : " ";
                string str = string.Concat(Enumerable.Repeat(" ", length / 2));

                Console.WriteLine("  ----------------------------------------------------------");
                Console.WriteLine(" |   É Feriado?   |   Data     |           Evento           |");
                Console.WriteLine("  ----------------------------------------------------------");
                Console.WriteLine(" |       Sim!    " + " | " + date + " | " + str + holidayList.Values.ToList()[index] + str + aux +  "|");
                Console.WriteLine("  ----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("  ----------------------------------------------------------");
                Console.WriteLine(" |   É Feriado?   |   Data     |          Evento            |");
                Console.WriteLine("  ----------------------------------------------------------");
                Console.WriteLine(" |       Não!    " + " | " + date + " |   Dia de trabalho Normal   |");
                Console.WriteLine("  ----------------------------------------------------------");
            }
        }

    }
}