using Application.HorseApp.IHorseRepos;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos
{
    public class HorseCrudRepository : IHorseCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseAsync(Horse horse)
        {
            await _context.Horses.AddAsync(horse);
        }

        public async Task UpdateHorseAsync(Horse horse)
        {
            _context.Horses.Update(horse);
        }

        public async Task DeleteHorseAsync(Horse horse)
        {
            _context.Horses.Remove(horse);
        }
    }
}
