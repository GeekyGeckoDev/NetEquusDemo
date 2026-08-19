using Domain.Entities.Models.Horses.Horsestats;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public interface IConfPerfTempAttributeService
    {
        Task CreateConfPerfTempAttAsync(ConfPerfTempAttributes attributes);
    }
}