using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.IHorseStatsRepos
{
    public interface IConformationAttRepository
    {
        Task CreateConfAttAsync(ConformationAttributes attributes);
    }
}