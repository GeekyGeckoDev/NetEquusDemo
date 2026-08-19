using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionCrudRepository: ICompetitionCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionCrudRepository(NetEquusDbContext context)
        { 
            _context = context; 
        }

        public async Task CreateCompetitionAsync (Competition comp)
        {
            await _context.Competitions.AddAsync(comp);
        }
    }
}
