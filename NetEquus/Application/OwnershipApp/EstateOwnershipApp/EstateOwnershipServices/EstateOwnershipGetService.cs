using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.EstateOwnershipServices
{
    public class EstateOwnershipGetService : IEstateOwnershipGetService
    {
        private readonly IEstateOwnershipGetRepository _estateOwnershipGetRepository;

        public EstateOwnershipGetService(IEstateOwnershipGetRepository repository)
        {
            _estateOwnershipGetRepository = repository;
        }

        public async Task<EquineEstate?> GetEstateOwnershipByUserIdAsync (Guid userId)
        {
            return await _estateOwnershipGetRepository.GetEstateOwnershipByUserId (userId);
        }
    }
}
