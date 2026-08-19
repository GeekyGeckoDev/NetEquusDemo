using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionEntryCrudService
    {
        Task CreateCompetitionEntryAsync(CompetitionEntry entry);
    }
}