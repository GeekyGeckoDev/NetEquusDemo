using Application.BreedApp.BreedStatsApp;
using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses.Horsestats;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public class GeneratePerformance : IGeneratePerformance
    {
        private readonly IGetBreedGenerationStatsService _getBreedGenerationStatsService;


        public GeneratePerformance(IGetBreedGenerationStatsService getBreedGenerationStatsService)
        {
            _getBreedGenerationStatsService = getBreedGenerationStatsService;
        }

        private static double ApplyEliteResistance(double value)
        {
            if (value >= 7.5 && Random.Shared.NextDouble() < 0.98)
                value -= Random.Shared.NextDouble() * 0.5;

            else if (value >= 7.0 && Random.Shared.NextDouble() < 0.75)
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
        public async Task<PerformanceAttributes> GeneratePerfStatsFromBreedAsync(Guid breedId)
        {
            var breedStats = await _getBreedGenerationStatsService
            .GetBreedGenerationStatsByBreedIdAsync(breedId);

            var performance = new PerformanceAttributes
            {
                Gaits = GetRandomValue(breedStats.GenerationStats, GenerationStat.Gaits),
                Scope = GetRandomValue(breedStats.GenerationStats, GenerationStat.Scope),
                Speed = GetRandomValue(breedStats.GenerationStats, GenerationStat.Speed),
                Agility = GetRandomValue(breedStats.GenerationStats, GenerationStat.Agility),
                Endurance = GetRandomValue(breedStats.GenerationStats, GenerationStat.Endurance),
                Stride = GetRandomValue(breedStats.GenerationStats, GenerationStat.Stride)
            };

            performance.Gaits = ApplyEliteResistance(performance.Gaits);
            performance.Scope = ApplyEliteResistance(performance.Scope);
            performance.Speed = ApplyEliteResistance(performance.Speed);
            performance.Agility = ApplyEliteResistance(performance.Agility);
            performance.Endurance = ApplyEliteResistance(performance.Endurance);
            performance.Stride = ApplyEliteResistance(performance.Stride);

            double[] horseStats = { performance.Gaits, performance.Scope, performance.Speed, performance.Agility, performance.Endurance, performance.Stride };

            double sum = horseStats.Sum();

            while (sum > 36)
            {
                int index = Random.Shared.Next(horseStats.Length);

                if (horseStats[index] > 2)
                {
                    horseStats[index] -= 0.1;
                    horseStats[index] = Math.Round(horseStats[index], 1);

                    sum = horseStats.Sum();
                }
            }

            performance.Gaits = horseStats[0];
            performance.Scope = horseStats[1];
            performance.Speed = horseStats[2];
            performance.Agility = horseStats[3];
            performance.Endurance = horseStats[4];
            performance.Stride = horseStats[5];

            return performance;

        }
    }
}
