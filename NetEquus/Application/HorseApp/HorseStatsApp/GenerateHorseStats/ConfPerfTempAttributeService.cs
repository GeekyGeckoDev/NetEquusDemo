using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public class ConfPerfTempAttributeService : IConfPerfTempAttributeService
    {
        private readonly IConfPerfTempAttributeRepository _confPerfTempRepository;

        public ConfPerfTempAttributeService(IConfPerfTempAttributeRepository confPerfTempRepository)
        {
            _confPerfTempRepository = confPerfTempRepository;
        }

        public async Task CreateConfPerfTempAttAsync (ConfPerfTempAttributes attributes)
        {
            await _confPerfTempRepository.CreateConfPerfTempAttAsync (attributes);
        }
    }
}
