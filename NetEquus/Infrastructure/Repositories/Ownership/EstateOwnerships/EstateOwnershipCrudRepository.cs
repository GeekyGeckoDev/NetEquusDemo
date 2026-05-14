using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Ownership.EstateOwnerships
{
    public class EstateOwnershipCrudRepository : IEstateOwnersipCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public EstateOwnershipCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateEstateOwnershipAsync (EstateOwnership estateOwnership)
        {
            await _context.EstateOwnerships.AddAsync(estateOwnership);

        }

        public async Task UpdateEstateOwnershipAsync (EstateOwnership estateOwnership)
        {
            _context.EstateOwnerships.Update(estateOwnership);
           
        }

        public async Task DeleteEstateOwnershipAsync (EstateOwnership estateOwnership)
        {
            _context.EstateOwnerships.Remove(estateOwnership);
   
        }

    }
}
