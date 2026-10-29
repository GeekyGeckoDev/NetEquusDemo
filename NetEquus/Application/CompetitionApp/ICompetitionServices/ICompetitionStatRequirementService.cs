using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionStatRequirementService
    {
        Task CreateCompetitionStatRequirementAsync(CompetitionStatRequirement compStatRequirement);

        Task<List<CompetitionStatRequirement>> GetCompetitionStatRequirementsAsync(CompetitionClass competitionClass);
    }
}
