using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionRepos
{
    public interface ICompetitionResultCrudRepository
    {
        Task CreateCompetitionResultAsync(CompetitionResult result);
    }
}