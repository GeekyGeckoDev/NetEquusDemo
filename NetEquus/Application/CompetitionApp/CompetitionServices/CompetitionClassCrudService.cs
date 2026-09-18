using Application.CompetitionApp.ICompetitionRepos;
using Application.CompetitionApp.ICompetitionServices;
using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.CompetitionServices
{
    public class CompetitionClassCrudService : ICompetitionClassCrudService
    {
        private readonly ICompetitionClassCrudRepository _repository;

        public CompetitionClassCrudService(ICompetitionClassCrudRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCompetitionClassAsync(CompetitionClass compClass)
        {
            await _repository.CreateCompetitionClassAsync(compClass);
        }

        public async Task<List<CompetitionClass>> GetAllCompetitionClassesAsync()
        {
            return await _repository.GetAllCompetitionClassesAsync();
        }
    }
}
