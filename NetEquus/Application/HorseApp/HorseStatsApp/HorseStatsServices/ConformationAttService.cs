using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.HorseStatsServices
{
    public class ConformationAttService : IConformationAttService
    {
        private readonly IConformationAttRepository _repository;

        public ConformationAttService(IConformationAttRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateConfAttAsync (ConformationAttributes attributes)
        {
            await _repository.CreateConfAttAsync(attributes);
        }
    }
}
