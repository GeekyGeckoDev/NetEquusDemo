using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public interface IBreedGenerationStatsRepository
    {
        Task CreateBreedGenerationStatAsync(BreedGenerationStats stat);

        Task UpdateBreedGenerationStatsAsync(BreedGenerationStats stat);
    }
}
