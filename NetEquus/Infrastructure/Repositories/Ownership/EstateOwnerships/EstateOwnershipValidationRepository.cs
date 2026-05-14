using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Ownership.EstateOwnerships
{
    public class EstateOwnershipValidationRepository : IEstateOwnershipValidationRepository
    {
        private readonly NetEquusDbContext _context;

        public EstateOwnershipValidationRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserAlreadyOwnsAnyEstateAsync(Guid userId)
        {
            return await _context.EstateOwnerships
                .AnyAsync(o => o.UserId == userId && o.IsPrimaryOwner);
        }
    }
}
