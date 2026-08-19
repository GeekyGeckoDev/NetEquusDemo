using Domain.DomainRules;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public interface IBreedGenMinMaxService
    {
        Task<RuleResult> UpdateBreedGenProfileAsync(BreedGenerationProfileDto dto);

        Task CreateBreedGenProfileAsync(Guid breedId);
    }
}
