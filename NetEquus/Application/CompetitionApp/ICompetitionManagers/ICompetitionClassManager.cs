using Domain.DomainRules;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionDisciplineServices
{
    public interface ICompetitionClassManager
    {
        Task<RuleResult> CreateCompetitionDisciplineWithClassAsync(
      CreateCompetitionDisciplineWithClassDto dto);

    }
}
