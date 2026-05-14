using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.UpdateHorse
{
    public class CalculateNextAgeingDate
    {
        public DateOnly CalculateAgeingDate (Horse horse)
        {
            DateOnly birthdate = horse.BirthDate;

            int cycleLength = 30;

            int daysAlive = DateOnly.FromDateTime(DateTime.Today).DayNumber;

            daysAlive = birthdate.DayNumber;

            int cyclespassed = daysAlive / cycleLength;

            DateOnly ageingDate = birthdate.AddDays(cyclespassed * cycleLength);

            return ageingDate;

        }
    }
}
