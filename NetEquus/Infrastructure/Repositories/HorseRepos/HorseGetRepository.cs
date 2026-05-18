using Application.HorseApp.IHorseRepos;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos
{
    public class HorseGetRepository : IHorseGetRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<Horse?> GetHorseByIdAsync (Guid horseId)
        {
            return await _context.Horses.FindAsync (horseId);
        }
    }
}
