using Domain.Enums;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.GenerateHorseInfo
{
    public class RandomHorseName
    {
        private static readonly Random rnd = new();
        public async Task<string> HorseNameRandomizer(HorseSex sex)
        {

            switch (sex)
            {
                case HorseSex.Mare:

                    Array mareValues = Enum.GetValues(typeof(HorseMareNames));

                    var horseMareName =
                        (HorseMareNames)mareValues.GetValue(
                            rnd.Next(mareValues.Length));

                    return horseMareName.ToString();

                case HorseSex.Stallion:

                    Array stallionValues = Enum.GetValues(typeof(HorseStallionNames));

                    var horseStallionName =
                        (HorseStallionNames)stallionValues.GetValue(
                            rnd.Next(stallionValues.Length));

                    return horseStallionName.ToString();

                default:
                    return "Unknown";
            }
        }
    }
}
