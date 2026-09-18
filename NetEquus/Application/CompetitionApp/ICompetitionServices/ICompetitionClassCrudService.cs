using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionClassCrudService
    {
        Task CreateCompetitionClassAsync(CompetitionClass compClass);

        Task<List<CompetitionClass>> GetAllCompetitionClassesAsync();
    }
}
