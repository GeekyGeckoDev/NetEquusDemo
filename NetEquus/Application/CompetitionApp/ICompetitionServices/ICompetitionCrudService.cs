using Domain.Entities.Models.Competitions;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionCrudService
    {
        Task CreateCompetitionAsync(Competition comp);
        
        }
}