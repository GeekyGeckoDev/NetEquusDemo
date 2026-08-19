using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.CompetitionsRepos
{
    public class CompetitionDisciplineRepository : ICompetitionDisciplineRepository
    {
        private readonly NetEquusDbContext _context;

        public CompetitionDisciplineRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompetitionDisciplineAsync (CompetitionDiscipline competitionDiscipline)
        {
            await  _context.CompetitionDisciplines.AddAsync (competitionDiscipline);
        }
    }
}
