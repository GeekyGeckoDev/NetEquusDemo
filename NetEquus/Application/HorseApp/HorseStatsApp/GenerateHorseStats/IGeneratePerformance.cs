using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public interface IGeneratePerformance
    {
        Task<PerformanceAttributes> GeneratePerfStatsFromBreedAsync(Guid breedId);
    }
}