using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.HorseStatsServices
{
    public interface IPerformanceAttService
    {
        Task CreatePerfAttAsync(PerformanceAttributes attributes);
    }
}