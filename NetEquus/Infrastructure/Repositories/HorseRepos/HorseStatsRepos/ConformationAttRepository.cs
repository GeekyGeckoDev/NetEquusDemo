using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos.HorseStatsRepos
{
    public  class ConformationAttRepository : IConformationAttRepository
    {
        private readonly NetEquusDbContext _context;

            public ConformationAttRepository (NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateConfAttAsync (ConformationAttributes attributes)
        {
            await _context.ConformationAttributes.AddAsync(attributes);
        }
    }
}
