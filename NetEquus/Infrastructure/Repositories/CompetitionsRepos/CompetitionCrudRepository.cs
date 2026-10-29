using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;
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

        public async Task UpdateCompetitionAsync(Competition comp)
        {
            _context.Competitions.Update(comp);
        }

        public async Task<Competition> getCompetitionById (Guid competitionId)
        {
            return await _context.Competitions.FindAsync(competitionId);
        }

        public async Task<List<CompetitionDto>> GetAllCompetitionsAsync()
        {
            return _context.Competitions
                .Select(c => new CompetitionDto
                {
                    Id = c.CompetitionId,

                    CompetitionClassDto = new CompetitionClassDto
                    {
                        CompetitionClassId = c.CompetitionClassId,
                        CompetitionDisciplineName =
                            c.Class.CompetitionDiscipline.Discipline.ToString(),
                        Name = c.Class.Name,
                        Level = c.Class.Level
                    },

                    Date = c.Date
                })
                .ToList();
        }
    }
    
}
