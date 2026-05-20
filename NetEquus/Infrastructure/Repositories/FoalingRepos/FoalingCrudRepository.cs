using Application.FoalingApp.IFoalingRepos;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.FoalingRepos
{
    public class FoalingCrudRepository : IFoalingCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public FoalingCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateFoalingAsync (Foaling foaling)
        {
            await _context.Foalings.AddAsync(foaling);
        }
    }
}
