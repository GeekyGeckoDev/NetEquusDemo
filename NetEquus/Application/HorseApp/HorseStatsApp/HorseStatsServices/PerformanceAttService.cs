using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.HorseStatsServices
{
    public class PerformanceAttService : IPerformanceAttService
    {
        private readonly IPerformanceAttributesRepository _repository;

        public PerformanceAttService(IPerformanceAttributesRepository repository)
        {  
            _repository = repository; 
        }
        public async Task CreatePerfAttAsync (PerformanceAttributes attributes)
        {
            await _repository.CreatePerfAttAsync (attributes);
        }
    }
}
