using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos.HorseStatsRepos
{
    public class PerformanceAttRepository : IPerformanceAttributesRepository
    {
        private readonly NetEquusDbContext _context;

        public PerformanceAttRepository (NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreatePerfAttAsync (PerformanceAttributes PerfAtt)
        {
            await _context.PerformanceAttributes.AddAsync(PerfAtt);
        }

        public async Task GetPerfAttByHorseIdAsync (Guid horseId)
        {
            await _context.PerformanceAttributes.FindAsync(horseId);
        }
    }
}
