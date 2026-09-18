using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionEntryService : ICompetitionEntryCrudService
    {
        private readonly ICompetitionEntryCrudRepository _repository;

        public CompetitionEntryService(ICompetitionEntryCrudRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCompetitionEntryAsync (CompetitionEntry entry)
        {
            await _repository.CreateCompetitionEntryAsync(entry);
        }
    }
}
