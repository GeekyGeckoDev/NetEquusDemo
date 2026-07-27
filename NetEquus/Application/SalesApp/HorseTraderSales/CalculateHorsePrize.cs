using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTraderSales
{
    public class CalculateHorsePrize
    {
        public static decimal CalculateHorseTraderPrize(decimal horseValue)
        {
            decimal prize = decimal.Multiply(horseValue, (decimal)0.75);

            return prize;
        }
    }
}
