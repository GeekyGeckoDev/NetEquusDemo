using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionCrudService : ICompetitionCrudService
    {
        private readonly ICompetitionCrudRepository _repository;

        public CompetitionCrudService(ICompetitionCrudRepository repository)
        {
            _repository = repository; 
        }

        public async Task CreateCompetitionAsync (Competition comp)
        {
            await _repository.CreateCompetitionAsync (comp);
        }
    }
}
