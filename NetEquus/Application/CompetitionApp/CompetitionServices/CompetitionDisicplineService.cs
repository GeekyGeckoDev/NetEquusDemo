using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionDisicplineService : ICompetitionDisicplineService
    {
        private readonly ICompetitionDisciplineRepository _repository;

        public CompetitionDisicplineService(ICompetitionDisciplineRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCompetitionAsync (CompetitionDiscipline compDiscipline)
        {
            await _repository.CreateCompetitionDisciplineAsync(compDiscipline);
        }


    }
}
