using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionClassCrudRepository : ICompetitionClassCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionClassCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompetitionClassAsync(CompetitionClass compClass)
        {
            await _context.CompetitionClasses.AddAsync(compClass);
        }

        public async Task<List<CompetitionClass>> GetAllCompetitionClassesAsync()
        {
            return _context.CompetitionClasses
                .ToList();
        }
    }

}
