using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.GenerateHorseInfo
{
    public class ValueCalculator
    {
        public static decimal CalculateFoalValue(decimal damValue, decimal studValue)
        {
            var foalValue = (damValue + studValue) / 2 ;

            decimal value = Decimal.Multiply(foalValue, (decimal)0.6);

            return value;

        }
    }
}
