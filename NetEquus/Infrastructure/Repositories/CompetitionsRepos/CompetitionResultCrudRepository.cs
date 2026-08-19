using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionResultCrudRepository : ICompetitionResultCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionResultCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompetitionResultAsync(CompetitionResult result)
        {
            await _context.CompetitionResults.AddAsync(result);
        }
    }
}
