using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public class BreedMinMaxStatService : IBreedMinMaxStatService
    { 
        private readonly IBreedMinMaxStatRepository _repository;

        public BreedMinMaxStatService(IBreedMinMaxStatRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBreedMinMaxStatAsync (BreedMinMaxStat minMax)
        {
            await _repository.CreateBreedMinMaxStatAsync(minMax);
        }

        public async Task UpdateBreedMinMaxStatAsync(BreedMinMaxStat minMax)
        {
            await _repository.UpdateBreedMinMaxStatAsync(minMax);
        }
    }
}
