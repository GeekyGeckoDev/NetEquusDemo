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
    public class EstateOwnershipCrudService : IEstateOwnershipCrudService
    {
        private readonly IEstateOwnersipCrudRepository _estateOwnershipRepository;

        public EstateOwnershipCrudService(IEstateOwnersipCrudRepository estateOwnershipRepository)
        {
            _estateOwnershipRepository = estateOwnershipRepository;
        }

        public async Task CreateEstateOwnershipAsync (EstateOwnership estateOwnership)
        {
            await _estateOwnershipRepository.CreateEstateOwnershipAsync(estateOwnership);

        }

        public async Task UpdateEstateOwnershipAsync (EstateOwnership estateOwnership)
        {
            await _estateOwnershipRepository.UpdateEstateOwnershipAsync(estateOwnership);
        }

        public async Task DeleteOwnershipAsync (EstateOwnership estateOwnership)
        {
            await _estateOwnershipRepository.DeleteEstateOwnershipAsync(estateOwnership);
        }
    }
}
