using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.GenerateFoalStats
{
    public class PerformanceAttribitesGenerationService
    {
        public static PerformanceAttributes GeneratePerfFoalFromParents(PerformanceAttributes dam, PerformanceAttributes sire, double damInheritanceMultiplyer, double damTrainabilityMultiplyer)
        {
            Random rnd = new Random();

            double[] damStats = { dam.Gaits, dam.Scope, dam.Speed, dam.Agility, dam.Endurance, dam.Stride, dam.Trainability };
            double[] sireStats = { sire.Gaits, sire.Scope, sire.Speed, sire.Agility, sire.Endurance, sire.Stride, sire.Trainability };
            // Get the number of items in damStats array.
            double[] foalStats = new double[damStats.Length];

            int maxedStatsCount = 0;

            for (int i = 0; i < damStats.Length; i++)
            {
                double damWeight = damStats[i] * 0.6;
                double sireWeight = sireStats[i] * 0.4;

                if (i == damStats.Length - 1)
                    damWeight *= damTrainabilityMultiplyer;
                else
                    damWeight *= damInheritanceMultiplyer;

                //Combining parents

                double value = damWeight + sireWeight;

                value += (rnd.NextDouble() - 0.5);

                foalStats[i] = value;
            }

            //Stat rules enforcements

            var lowIndexes = Enumerable.Range(0, foalStats.Length).Where(i => foalStats[i] < 4).ToList();

            int toRaise = Math.Min(2, lowIndexes.Count);

            for (int i = 0; i < toRaise; i++)
            {
                int index = lowIndexes[rnd.Next(lowIndexes.Count)];
                foalStats[index] = 4 + rnd.NextDouble();
                lowIndexes.Remove(index);

            }

            double sum = foalStats.Sum();
            if(sum > 52)
            {
                double scale = 52 / sum;
                for (int i = 0; i < foalStats.Length; i++)
                    foalStats[i] *= scale;
            }

            return new PerformanceAttributes
            {
                Gaits = Math.Round(foalStats[0], 1),
                Scope = Math.Round(foalStats[1], 1),
                Speed = Math.Round(foalStats[2], 1),
                Agility = Math.Round(foalStats[3], 1),
                Endurance = Math.Round(foalStats[4], 1),
                Stride = Math.Round(foalStats[5], 1)
            };


        }
    }
}
