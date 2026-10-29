using Domain.DomainRules;
using Shared.Dtos.CompetitionDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionManagers
{
    public interface ICompetitionManager
    {
        Task<RuleResult> CreateCompetitionAsync(CreateCompetitionDto dto);
        Task<RuleResult> CreateCompetitionEntryAsync(
        CreateCompetitionEntryDto dto);
    }
}
