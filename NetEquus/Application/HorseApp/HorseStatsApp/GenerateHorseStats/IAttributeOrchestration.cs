using Domain.Entities.Models.Horses;

namespace Application.HorseApp.HorseStatsApp.GenerateHorseStats
{
    public interface IAttributeOrchestration
    {
        Task GenerateCreateAttributesAsync(Horse horse);
    }
}