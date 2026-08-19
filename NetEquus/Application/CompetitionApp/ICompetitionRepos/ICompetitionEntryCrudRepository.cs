using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionRepos
{
    public interface ICompetitionEntryCrudRepository
    {
        Task CreateCompetitionEntryAsync(CompetitionEntry entry);
    }
}