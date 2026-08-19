using Domain.Entities.Models.Breeds;

namespace Application.BreedApp.BreedStatsApp
{
    public interface IGetBreedGenerationStatsService
    {
        Task<BreedGenerationStats> GetBreedGenerationStatsByBreedIdAsync(Guid breedId);
    }
}