using Application.HorseApp.HorseStatsApp.IHorseStatsRepos;
using Domain.Entities.Models.Horses.Horsestats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos.HorseStatsRepos
{
    public class ConfPerfTempAttributeRepository : IConfPerfTempAttributeRepository
    {
        private readonly NetEquusDbContext _context;

        public ConfPerfTempAttributeRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateConfPerfTempAttAsync (ConfPerfTempAttributes attributes)
        {
            await _context.ConfPerfTempAttributes.AddAsync (attributes);
        }
    }
}
