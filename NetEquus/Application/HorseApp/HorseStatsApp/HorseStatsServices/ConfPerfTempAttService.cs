using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.HorseStatsServices
{
    public class ConfPerfTempAttService
    {
        private readonly IConfPerfTempAttributeRepository _repository;

        public ConfPerfTempAttService(IConfPerfTempAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateConfPerfTempAttAsync (ConfPerfTempAttributes attributes)
        {
            await _repository.CreateConfPerfTempAttAsync(attributes);
        }
    }
}
