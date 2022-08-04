using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrazilianHolidays
{
    internal class EasterDateCalculator
    {
        private DateTime easterFullDate;
        private int year;

        public EasterDateCalculator(int year)
        {
            this.year = year;
        }

        public DateTime calculateEasterDate()
        {
            var yearPositionMetonicCycle = year % 19;// Year's position on the 19 year metonic cycle

            var centuryIndex = Math.Floor(year / 100.0);// Century index

            var addDayOffset = Math.Floor((13 + 8 * centuryIndex) / 25.0);// Shift of metonic cycle, add a day offset every 300 years

            var nonObservedLeapDays = Math.Floor(centuryIndex / 4.0);// Correction for non-observed leap days

            var startingPointCalculation = (15 - addDayOffset + centuryIndex - nonObservedLeapDays) % 30;// Correction to starting point of calculation each century

            var daysUntilFullMoon = (19 * yearPositionMetonicCycle + startingPointCalculation) % 30;// Number of days from March 21st until the full moon

            var nextSunday = (4 + centuryIndex - nonObservedLeapDays) % 7;//Finding the next Sunday | Century-based offset in weekly calculation

            var leapDaysB = year % 4;// Correction for leap days
            var leapDaysC = year % 7;// Correction for leap days

            var daysFromFullMoonToNextSunday = (2 * leapDaysB + 4 * leapDaysC + 6 * daysUntilFullMoon + nextSunday) % 7;// Days from d to next Sunday

            //Historical corrections for April 26 and 25
            if((daysUntilFullMoon == 29 && daysFromFullMoonToNextSunday == 6)
                || (daysUntilFullMoon == 28 && daysFromFullMoonToNextSunday == 6 && yearPositionMetonicCycle > 10))
            {
                daysFromFullMoonToNextSunday = - 1;
            }

            var easterDay = 0.0;
            var easterMonth = "";
            var stringEasterDate = "";

            // Determination of the correct month for Easter
            if(22 + daysUntilFullMoon + daysFromFullMoonToNextSunday > 31)
            {
                easterDay = daysUntilFullMoon + daysFromFullMoonToNextSunday - 9;
                easterMonth = "/04";
            }
            else
            {
                easterDay = 22 + daysUntilFullMoon + daysFromFullMoonToNextSunday;
                easterMonth = "/03";
            }
            stringEasterDate = easterDay < 10 ? "0" + Convert.ToString(easterDay) + easterMonth + "/" + year.ToString(): Convert.ToString(easterDay) + easterMonth + "/" + year.ToString();

            easterFullDate = DateTime.ParseExact(stringEasterDate, "dd/MM/yyyy", null);

            return easterFullDate;
        }
    }
}
