using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Domain.Entities.Models.Horses.Relations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Ownership.HorseOwnerships
{
    public class HorseOwnershipGetRepository : IHorseOwnershipGetRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseOwnershipGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<HorseOwnership> GetOwnershipByHorseId (Guid horseId)
        {
            return await _context.HorseOwnerships
                .Include(o => o.User)
                .Include(o => o.Horse)
                .ThenInclude(h => h.Breed)
                .FirstOrDefaultAsync(o => o.HorseGuidId == horseId);
        }
    }
}
