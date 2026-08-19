using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionResultCrudService
    {
        Task CreateCompetitionResultAsync(CompetitionResult result);
    }
}