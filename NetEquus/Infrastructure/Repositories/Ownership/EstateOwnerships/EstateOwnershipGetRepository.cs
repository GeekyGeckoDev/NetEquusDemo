using Application.EstateApp.EstateDtos;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Application.SharedApp.OwnershipMappers;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.OwnershipDtos;
using Shared.Mappers.EstateMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Ownership.EstateOwnerships
{
    public class EstateOwnershipGetRepository : IEstateOwnershipGetRepository
    {
        private readonly NetEquusDbContext _context;

        public EstateOwnershipGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<EstateOwnershipDto?> GetEstateOwnershipByUserId (Guid userId)
        {
            var estate = await _context.EquineEstates
            .Include(e => e.EstateOwners) // so you can actually see the owners
            .FirstOrDefaultAsync(e => e.EstateOwners.Any(owner => owner.UserId == userId));

            if (estate == null)
                return null;

            return new EstateOwnershipDto
            {
                EquineEstateId = estate.EstateId,

                UserId = userId,
          
            };

        }
    }
}
