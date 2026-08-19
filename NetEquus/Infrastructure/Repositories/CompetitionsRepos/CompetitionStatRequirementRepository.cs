using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionStatRequirementRepository : ICompetitionStatRequirementRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionStatRequirementRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompetitionStatRequirementAsync (CompetitionStatRequirement requirement)
        {
            await _context.GetCompetitionStatRequirments.AddAsync (requirement);
        }
    }
}
