using Application.CompetitionApp.ICompetitionRepos;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionDisicplineCrudService
    {
        private readonly ICompetitionDisciplineRepository _repository;

        public CompetitionDisicplineCrudService(ICompetitionDisciplineRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCompetitionAsync (CompetitionDiscipline compDiscipline)
        {
            await _repository.CreateCompetitionDisciplineAsync(compDiscipline);
        }


    }
}
