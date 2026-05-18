using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.UpdateHorse
{
    public class HorseDateHelper
    {
        public DateOnly CalculateBirthDate(int age)
        {
            const int DaysPerYear = 30;

            return DateOnly.FromDateTime(
                DateTime.UtcNow.AddDays(-(age * DaysPerYear)));
        }
    }
}
