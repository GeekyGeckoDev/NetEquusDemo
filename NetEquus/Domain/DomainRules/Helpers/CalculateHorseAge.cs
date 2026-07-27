using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainRules.Helpers
{
    public class CalculateHorseAge
    {
        public static int CalculateHorseAgeMapper(Horse horse)
        {
            DateOnly birthdate = horse.BirthDate;

            int cycleLength = 20;

            int daysAlive =
                DateOnly.FromDateTime(DateTime.Today).DayNumber
                - birthdate.DayNumber;

            int cyclesPassed = daysAlive / cycleLength;

            return cyclesPassed;
        }

        public static DateOnly CalculateBirthdate (int age)
        {
            int cycleLength = 20;

            return DateOnly.FromDateTime(
            DateTime.UtcNow.AddDays(-(age * cycleLength)));


        }

        public static DateOnly CalculateAgeingDate(Horse horse)
        {
            DateOnly birthdate = horse.BirthDate;

            int cycleLength = 20;

            int daysAlive = DateOnly.FromDateTime(DateTime.Today).DayNumber;

            daysAlive = birthdate.DayNumber;

            int cyclespassed = daysAlive / cycleLength;

            DateOnly ageingDate = birthdate.AddDays(cyclespassed * cycleLength);

            return ageingDate;

        }



    }
}