using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionStatRequirementService : ICompetitionStatRequirementService
    {
        private readonly ICompetitionStatRequirementRepository _competitionStatRequirementRepository;

        public CompetitionStatRequirementService(ICompetitionStatRequirementRepository competitionStatRequirementRepository)
        {
            _competitionStatRequirementRepository = competitionStatRequirementRepository;
        }

        public async Task CreateCompetitionStatRequirementAsync(CompetitionStatRequirement requirement)
        {
            await _competitionStatRequirementRepository.CreateCompetitionStatRequirementAsync(requirement);
        }
    }
}
