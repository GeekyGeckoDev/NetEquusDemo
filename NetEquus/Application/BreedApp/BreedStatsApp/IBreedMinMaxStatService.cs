using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedStatsApp
{
    public interface IBreedMinMaxStatService
    {
        Task CreateBreedMinMaxStatAsync(BreedMinMaxStat minMax);

        Task UpdateBreedMinMaxStatAsync(BreedMinMaxStat minMax);
    }
}
