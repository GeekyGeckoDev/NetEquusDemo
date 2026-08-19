using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionEntryCrudRepository : ICompetitionEntryCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionEntryCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompetitionEntryAsync(CompetitionEntry entry)
        {
            await _context.CompetitionEntries.AddAsync(entry);
        }
    }
}
