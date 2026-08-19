using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionResultCrudService : ICompetitionResultCrudService
    {
        private readonly ICompetitionResultCrudRepository _repository;

        public CompetitionResultCrudService (ICompetitionResultCrudRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCompetitionResultAsync (CompetitionResult result)
        { 
            await _repository.CreateCompetitionResultAsync(result); 
        }
    }
}
