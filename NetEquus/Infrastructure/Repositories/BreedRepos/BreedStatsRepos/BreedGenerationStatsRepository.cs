using Application.BreedApp.BreedStatsApp;
using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BreedRepos.BreedStatsRepos
{
    public class BreedGenerationStatsRepository : IBreedGenerationStatsRepository
    {
        private readonly NetEquusDbContext _context;

        public BreedGenerationStatsRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateBreedGenerationStatAsync (BreedGenerationStats stat)
        {
            await _context.BreedGenerationStats.AddAsync(stat);

        }

        public async Task UpdateBreedGenerationStatsAsync(BreedGenerationStats stat)
        {
            _context.BreedGenerationStats.Update(stat);
        }
    }
}
