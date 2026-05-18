using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipRepos;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.SharedApp.OwnershipMappers;
using Domain.DomainRules;
using Domain.DomainRules.EstateRules;
using Domain.DomainRules.SharedRules;
using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OwnershipApp.EstateOwnershipApp.EstateOwnershipServices
{
    public class EstateOwnershipValidationService : IEstateOwnershipValidationService
    {
        private readonly IEstateOwnershipValidationRepository _estateOwnershipValidationRepository;

        public EstateOwnershipValidationService(IEstateOwnershipValidationRepository estateOwnershipValidationReposiotry)
        {
            _estateOwnershipValidationRepository = estateOwnershipValidationReposiotry;
        }

        public async Task<RuleResult> CheckUserCanCreateEstateAsync(Guid userId)
        {
            var alreadyOwnsEstate = await _estateOwnershipValidationRepository.UserAlreadyOwnsAnyEstateAsync(userId);

            if (alreadyOwnsEstate)
                return RuleResult.Fail("User already owns an estate.");

            return RuleResult.Success();
        }
    }
}
