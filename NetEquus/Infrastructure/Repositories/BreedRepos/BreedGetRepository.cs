using Application.BreedApp.IBreedRepos;
using Domain.Entities.Models.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BreedRepos
{
    public class BreedGetRepository : IBreedGetRepository
    {

        private readonly NetEquusDbContext _context;

        public BreedGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }
        public async Task<List<Breed?>> GetAllBreedsAsync()
        {

            return _context.Breeds.ToList();
        }

        public async Task<Breed> GetBreedByIdAsync(Guid breedId)
        {
            return await _context.Breeds.FindAsync(breedId);
        }
    }
}
