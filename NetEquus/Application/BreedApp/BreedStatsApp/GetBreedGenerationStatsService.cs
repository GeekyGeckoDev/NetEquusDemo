using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public class GetBreedGenerationStatsService : IGetBreedGenerationStatsService
    {
        private readonly IGetBreedGenerationStatsRepository _repository;

        public GetBreedGenerationStatsService(IGetBreedGenerationStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BreedGenerationStats> GetBreedGenerationStatsByBreedIdAsync(Guid breedId)
        {
            return await _repository.GetBreedGenerationStatsByBreedIdAsync(breedId);
        }
    }
}
