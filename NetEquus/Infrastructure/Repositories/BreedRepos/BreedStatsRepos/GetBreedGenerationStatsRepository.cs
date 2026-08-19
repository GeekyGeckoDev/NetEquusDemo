using Application.BreedApp.BreedStatsApp;
using Domain.Entities.Models.Breeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BreedRepos.BreedStatsRepos
{
    public class GetBreedGenerationStatsRepository : IGetBreedGenerationStatsRepository
    {
        private readonly NetEquusDbContext _context;

        public GetBreedGenerationStatsRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<BreedGenerationStats> GetBreedGenerationStatsByBreedIdAsync(Guid breedId)
        {
            return await _context.BreedGenerationStats
                .Include(x => x.GenerationStats)
                .FirstOrDefaultAsync(x => x.BreedId == breedId);
        }
    }
}
