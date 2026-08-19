using Application.BreedApp.BreedStatsApp;
using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BreedRepos.BreedStatsRepos
{
    public class BreedMinMaxStatRepository : IBreedMinMaxStatRepository
    {
        private readonly NetEquusDbContext _context;

        public BreedMinMaxStatRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateBreedMinMaxStatAsync (BreedMinMaxStat minMax)
        {
            await _context.BreedMinMaxStats.AddAsync(minMax);
        }

        public async Task UpdateBreedMinMaxStatAsync (BreedMinMaxStat minMax)
        {
            _context.BreedMinMaxStats.Update(minMax);
        }
    }
}
