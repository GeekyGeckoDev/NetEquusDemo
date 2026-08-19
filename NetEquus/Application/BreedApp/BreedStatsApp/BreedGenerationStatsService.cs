using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public class BreedGenerationStatsService : IBreedGenerationStatsService
    {
        private readonly IBreedGenerationStatsRepository _repository;

        public BreedGenerationStatsService(IBreedGenerationStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBreedGenerationStatsAsync (BreedGenerationStats Stats)
        {
            await _repository.CreateBreedGenerationStatAsync (Stats);
        }

        public async Task UpdateBreedGenerationStatsAsync (BreedGenerationStats Stats)
        {
            await _repository.UpdateBreedGenerationStatsAsync(Stats);
        }
    }
}
