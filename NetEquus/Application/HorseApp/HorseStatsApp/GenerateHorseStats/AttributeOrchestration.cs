using Application.HorseApp.HorseStatsApp.HorseStatsServices;
using Domain.Entities.Models.Horses;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public class AttributeOrchestration : IAttributeOrchestration
    {

        private readonly IGeneratePerformance _generatePerfService;

        private readonly IGenerateConformation _generateConformationService;

        private readonly IConfPerfTempAttributeService _confPerfTempAttributeService;

        private readonly IConformationAttService _conformationAttService;

        private readonly IPerformanceAttService _performanceAttService;

        public AttributeOrchestration(IGeneratePerformance generatePerfService, IGenerateConformation generateConformationService, IConfPerfTempAttributeService confPerfTempAttributeService, IPerformanceAttService performanceAttService, IConformationAttService conformationAttService)
        {
            _generatePerfService = generatePerfService;
            _generateConformationService = generateConformationService;
            _confPerfTempAttributeService = confPerfTempAttributeService;
            _performanceAttService = performanceAttService;
            _conformationAttService = conformationAttService;
        }

        public async Task GenerateCreateAttributesAsync (Horse horse)
        {
            var conf = await _generateConformationService.GenerateConfStatsFromBreedAsync(horse.BreedId);

            await _conformationAttService.CreateConfAttAsync(conf);

            var perf = await _generatePerfService.GeneratePerfStatsFromBreedAsync (horse.BreedId);

            await _performanceAttService.CreatePerfAttAsync(perf);

            var confPerfTemp = new ConfPerfTempAttributes
            {
                PerfId = perf.PerfId,

                ConfId = conf.ConfId,

                GuidHorseId = horse.GuidHorseId,

            };

            await _confPerfTempAttributeService.CreateConfPerfTempAttAsync(confPerfTemp);
        }
    }
}
