using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.UpdateHorse
{
  
        public static class HorseAgeCalculator
        {
            public const int DaysPerYear = 20;

            public static DateOnly GenerateBirthDate(int age)
            {
                return DateOnly.FromDateTime(
                    DateTime.UtcNow.AddDays(-(age * DaysPerYear)));
            }

            public static int CalculateAge(DateOnly birthDate)
            {
                int daysAlive =
                    DateOnly.FromDateTime(DateTime.UtcNow).DayNumber
                    - birthDate.DayNumber;

                return daysAlive / DaysPerYear;
            }
    }
}
