using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp.HorseStatsApp.IHorseStatsRepos
{
    public interface IPerformanceAttributesRepository
    {
        Task CreatePerfAttAsync(PerformanceAttributes PerfAtt);

        Task GetPerfAttByHorseIdAsync(Guid horseId);
    }
}
