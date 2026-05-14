using Application.EstateApp.EstateDtos;
using Application.EstateApp.EstateMappers;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.EstateOwnershipServices
{
    public class EstateOwnershipOrchestrationService : IEstateOwnershipOrchestrationService
    {
        private readonly IEstateOwnershipCrudService _estateOwnershipCrudService;

        public EstateOwnershipOrchestrationService(IEstateOwnershipCrudService estateOwnershipCrudService)
        {
            _estateOwnershipCrudService = estateOwnershipCrudService;
        }

        public async Task LinkUserToEstateAsync(Guid userId, Guid estateId, bool isPrimaryOwner)
        {
            var ownership = new EstateOwnership
            {
                UserId = userId,
                EstateId = estateId,
                IsPrimaryOwner = isPrimaryOwner
            };

            await _estateOwnershipCrudService.CreateEstateOwnershipAsync(ownership);

        }
    }

}