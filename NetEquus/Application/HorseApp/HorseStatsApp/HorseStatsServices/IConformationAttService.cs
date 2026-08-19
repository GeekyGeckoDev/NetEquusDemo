using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.HorseStatsServices
{
    public interface IConformationAttService
    {
        Task CreateConfAttAsync(ConformationAttributes attributes);
    }
}