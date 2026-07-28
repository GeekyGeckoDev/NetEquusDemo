using Application.FoalingApp.IFoalingServices;
using Domain.DomainRules;
using Domain.DomainRules.BreedingRules;
using Domain.DomainRules.BreedingRules.BreedingGroupRules;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.FoalingServices
{
    public class FoalingValidationService : IFoalingValidationService
    {
        public async Task<RuleResult> CheckFoalingRules (Horse dam, Horse sire)
        {
            return BreedingDelegateCheckAll.CheckAll(dam, sire, BreedingRules.Mature,
                BreedingRules.OppositeSex,
                BreedingRules.NotSameHorse,
                BreedingGroupRules.SameHorseBreed);
        }
    }
}
