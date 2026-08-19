using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public interface IGenerateConformation
    {
        Task<ConformationAttributes> GenerateConfStatsFromBreedAsync(Guid breedId);
    }
}