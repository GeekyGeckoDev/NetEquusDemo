using Domain.Entities.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionDisicplineService
    {
        Task CreateCompetitionAsync(CompetitionDiscipline compDiscipline);
    }
}
