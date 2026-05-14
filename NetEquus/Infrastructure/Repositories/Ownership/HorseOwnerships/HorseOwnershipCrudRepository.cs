using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipRepos;
using Domain.Entities.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Ownership.HorseOwnerships
{
    public class HorseOwnershipCrudRepository : IHorseOwnershipCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseOwnershipCrudRepository(NetEquusDbContext context)
        {
            _context = context;

        }

        public async Task CreateHorseOwnershipAsync (HorseOwnership horseOwnership)
        {
            await _context.HorseOwnerships.AddAsync (horseOwnership);
        }

        public async Task UpdateHorseOwnershipAsync(HorseOwnership horseOwnership)
        {
            _context.HorseOwnerships.Update (horseOwnership);
        }

        public async Task DeleteHorseOwnerShipAsync (HorseOwnership horseOwnership)
        {
            _context.HorseOwnerships.Remove(horseOwnership);
        }
    }
}
