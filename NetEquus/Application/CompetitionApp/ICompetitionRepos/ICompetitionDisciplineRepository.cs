using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionRepos
{
    public interface ICompetitionDisciplineRepository
    {
        Task CreateCompetitionDisciplineAsync(CompetitionDiscipline competitionDiscipline);
    }
}
