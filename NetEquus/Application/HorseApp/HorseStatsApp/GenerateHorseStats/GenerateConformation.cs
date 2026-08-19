using Application.BreedApp.BreedStatsApp;
using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses.Horsestats;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public class GenerateConformation : IGenerateConformation
    {
        private readonly IGetBreedGenerationStatsService _getBreedGenerationStatsService;

        public GenerateConformation (IGetBreedGenerationStatsService getBreedGenerationStatsService)
        {
            _getBreedGenerationStatsService = getBreedGenerationStatsService;
        }

        private static double ApplyEliteResistance(double value)
        {
            if (value >= 7.0 && Random.Shared.NextDouble() < 0.98)
                value -= Random.Shared.NextDouble() * 0.5;

            else if (value >= 6.5 && Random.Shared.NextDouble() < 0.75)
                value -= Random.Shared.NextDouble() * 0.3;

            return Math.Round(value, 1);
        }


        private static double GetRandomValue(
        IEnumerable<BreedMinMaxStat> stats,
        GenerationStat attribute)
        {
            var range = stats.Single(x => x.Attribute == attribute);

            // Bell curve
            double t =
            (
                Random.Shared.NextDouble() +
                Random.Shared.NextDouble() +
                Random.Shared.NextDouble()
            ) / 3.0;

            // Bias downward slightly
            t *= 0.90;

            t = Math.Clamp(t, 0, 1);

            return Math.Round(
                range.Min + ((range.Max - range.Min) * t),
                1);
        }

        public async Task<ConformationAttributes> GenerateConfStatsFromBreedAsync (Guid breedId)
        {
            var breedStats = await _getBreedGenerationStatsService.GetBreedGenerationStatsByBreedIdAsync(breedId);

            var conformation = new ConformationAttributes
            {
                Legs = GetRandomValue(breedStats.GenerationStats, GenerationStat.Legs),

                Shoulders = GetRandomValue(breedStats.GenerationStats, GenerationStat.Shoulders),

                Hindquarters = GetRandomValue(breedStats.GenerationStats, GenerationStat.Hindquarters),

                Pasterns = GetRandomValue(breedStats.GenerationStats, GenerationStat.Pasterns),

                BackAndLoin = GetRandomValue(breedStats.GenerationStats, GenerationStat.BackAndLoin),


                Head = GetRandomValue(breedStats.GenerationStats, GenerationStat.Head),
                Neck = GetRandomValue(breedStats.GenerationStats, GenerationStat.Neck),
                ChestAndBarrel = GetRandomValue(breedStats.GenerationStats, GenerationStat.ChestAndBarrel),
                BackAndTopline = GetRandomValue(breedStats.GenerationStats, GenerationStat.BackAndTopLine)

            };

            conformation.Legs = ApplyEliteResistance(conformation.Legs);
            conformation.Shoulders = ApplyEliteResistance(conformation.Shoulders);
            conformation.Hindquarters = ApplyEliteResistance(conformation.Hindquarters);
            conformation.Pasterns = ApplyEliteResistance(conformation.Pasterns);
            conformation.BackAndLoin = ApplyEliteResistance(conformation.BackAndLoin);

            conformation.Head = ApplyEliteResistance(conformation.Head);
            conformation.Neck = ApplyEliteResistance(conformation.Neck);
            conformation.ChestAndBarrel = ApplyEliteResistance(conformation.ChestAndBarrel);
            conformation.BackAndTopline = ApplyEliteResistance(conformation.BackAndTopline);

            return conformation;


        }
    }
}

    
