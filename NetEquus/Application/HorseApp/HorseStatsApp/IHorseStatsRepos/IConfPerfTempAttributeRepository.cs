using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.IHorseStatsRepos
{
    public interface IConfPerfTempAttributeRepository
    {
        Task CreateConfPerfTempAttAsync(ConfPerfTempAttributes attributes);
    }
    
}