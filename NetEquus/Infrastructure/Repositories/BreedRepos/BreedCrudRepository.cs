using Application.BreedApp.IBreedRepos;
using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BreedRepos
{
    public class BreedCrudRepository : IBreedCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public BreedCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateBreedAsync (Breed breed)
        {
            await _context.Breeds.AddAsync(breed);
        }

        public async Task UpdateBreedAsync(Breed breed)
        {
            _context.Breeds.Update(breed);
        }

        public async Task DeleteBreedAsync (Breed breed)
        {
            _context.Breeds.Remove(breed);
        }
    }
}
