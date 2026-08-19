using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Breeds;
using Shared.Dtos;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public class BreedGenMinMaxService : IBreedGenMinMaxService
    {
        private readonly IBreedGenerationStatsService _statsService;
        private readonly IBreedMinMaxStatService _minStatService;
        private readonly IGetBreedGenerationStatsService _getStatsService;
        private readonly IUnitOfWork _unitOfWork;

        public BreedGenMinMaxService(IBreedGenerationStatsService statsService, IBreedMinMaxStatService minStatService, IGetBreedGenerationStatsService getStatsService, IUnitOfWork unitOfWork )
        {
            _statsService = statsService;
            _minStatService = minStatService;
            _getStatsService = getStatsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> UpdateBreedGenProfileAsync(BreedGenerationProfileDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {

                    var profile = await _getStatsService.GetBreedGenerationStatsByBreedIdAsync(dto.BreedId);

            foreach (var updated in dto.Stats)
            {
                var stat = profile.GenerationStats
                    .First(s => s.Attribute == (Domain.Enums.GenerationStat)updated.GenStat);

                stat.Min = updated.Min;
                stat.Max = updated.Max;

                await _minStatService.UpdateBreedMinMaxStatAsync(stat);


            }

                });

                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail($"Horse creation failed; {ex.Message}");
            }
        }

        public async Task CreateBreedGenProfileAsync(Guid breedId)
        {
            var profile = new BreedGenerationStats
            {
                BreedId = breedId,
                GenerationStats = new List<BreedMinMaxStat>()
            };

            foreach (GenerationStat stat in Enum.GetValues<GenerationStat>())
            {
                profile.GenerationStats.Add(new BreedMinMaxStat
                {
                    Attribute = (Domain.Enums.GenerationStat)stat,
                    Min = 0,
                    Max = 0
                });
            }

            await _statsService.CreateBreedGenerationStatsAsync(profile);
        }

    }
}
