using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos.CompDisciplineDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionRepos
{
    public interface ICompetitionClassCrudRepository
    {
        Task CreateCompetitionClassAsync(CompetitionClass compClass);

        Task<List<CompetitionClassDto>> GetAllCompetitionClassesAsync();
    }
}
