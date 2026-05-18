using Domain.DomainRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseApp
{
    public interface IHorseRelations
    {
        Task<RuleResult> UpdateBoardingAndOwnership(
    Guid horseId,
    Guid newEstateId);
    }
}
