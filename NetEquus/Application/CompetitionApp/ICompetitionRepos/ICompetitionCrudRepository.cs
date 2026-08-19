using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionRepos
{
    public interface ICompetitionCrudRepository
    {
        Task CreateCompetitionAsync(Competition comp);
    }
}