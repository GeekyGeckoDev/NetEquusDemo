using Domain.DomainRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.FoalingHorseApp
{
    public interface IFoalingHorseManagerService
    {
        Task<RuleResult> CreateHorseOwnershipBoardingFoalingAsync(Guid dam, Guid sire);
    }
}
