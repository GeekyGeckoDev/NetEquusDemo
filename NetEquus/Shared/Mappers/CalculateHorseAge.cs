using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers
{
    public class CalculateHorseAge
    {
        public static int CalculateHorseAgeMapper(Horse horse)
        {
            DateOnly birthdate = horse.BirthDate;

            int cycleLength = 30;

            int daysAlive =
                DateOnly.FromDateTime(DateTime.Today).DayNumber
                - birthdate.DayNumber;

            int cyclesPassed = daysAlive / cycleLength;

            return cyclesPassed;
        }

    }
}
