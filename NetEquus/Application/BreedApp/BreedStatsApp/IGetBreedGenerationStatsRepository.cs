using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public interface IGetBreedGenerationStatsRepository
    {
        Task<BreedGenerationStats> GetBreedGenerationStatsByBreedIdAsync(Guid breedId);

    }
}
