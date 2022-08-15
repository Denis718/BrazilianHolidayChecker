using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installments
{
    public class Installments
    {
        private string date;

        public Installments(string date)
        {
            this.date = date;
        }
        public string Date
        {
            get { return date; }
        }

        private string convertToBusinessDay(string date)
        {
            IBrazilianHolidays brazilianHolidays = new BrazilianHolidays();
            var holidayList = brazilianHolidays.GetHolidays(date);

            var daysMonth = date.Substring(0, 5);
            var fullDateInstallment = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            if (holidayList.ContainsKey(daysMonth))
            {
                fullDateInstallment = fullDateInstallment.AddDays(1);
            }

            DayOfWeek wk = fullDateInstallment.DayOfWeek;

            if (wk.ToString().Equals("Saturday"))
            {
                fullDateInstallment = fullDateInstallment.AddDays(2);
                return fullDateInstallment.ToString("dd/MM/yyyy");
            }

            if (wk.ToString().Equals("Sunday"))
            {
                fullDateInstallment = fullDateInstallment.AddDays(1);
                return fullDateInstallment.ToString("dd/MM/yyyy");
            }

            return fullDateInstallment.ToString("dd/MM/yyyy");
        }

        public void twelveInstallments()
        {

            var firstInstallment = DateTime.ParseExact(date, "dd/MM/yyyy", null);

            Dictionary<int, string> installments = new Dictionary<int, string>();

            for(int i = 0; i < 12; i++)
            {
                installments.Add(i + 1, firstInstallment.AddMonths(i).ToString("dd/MM/yyyy"));
            }

            foreach(var installment in installments)
            {
                var date = installment.Value;
                installments[installment.Key] = convertToBusinessDay(date);
            }


            var whiteSpace = " ";
            Console.WriteLine("  -----------------------------");
            Console.WriteLine(" |   Parcela  |     Data       |");
            Console.WriteLine("  -----------------------------");
            foreach (var installment in installments)
            {
                whiteSpace = installment.Key < 10 ? " " : "";
                Console.WriteLine($" |{whiteSpace}     {installment.Key}     |   {installment.Value}   | ");
                Console.WriteLine("  -----------------------------");
            }

        }

    }
}