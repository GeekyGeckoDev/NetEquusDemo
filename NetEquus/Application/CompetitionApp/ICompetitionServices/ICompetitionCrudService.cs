using Domain.Entities.Models.Competitions;
using Shared.Dtos.CompetitionDtos;

namespace Application.CompetitionApp.ICompetitionServices
{
    public interface ICompetitionCrudService
    {
        Task CreateCompetitionAsync(Competition comp);

        Task UpdateCompetitionAsync(Competition comp);

        Task<Competition> getCompetitionById(Guid competitionId);

        Task<List<CompetitionDto>> GetAllCompetitionsAsync();


    }
}