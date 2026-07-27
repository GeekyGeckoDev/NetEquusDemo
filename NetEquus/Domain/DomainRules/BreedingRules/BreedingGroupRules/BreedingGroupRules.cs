using System;
using System.Collections.Generic;
using System.Text;
using static Domain.DomainRules.BreedingRules.BreedingDelegateCheckAll;

namespace Domain.DomainRules.BreedingRules.BreedingGroupRules
{
    public static class BreedingGroupRules
    {
        public static HorsePairRule SameHorseBreed = (dam, sire) =>
        dam.BreedId == sire.BreedId ? RuleResult.Success() : RuleResult.Fail("Horse cannot breed with itself.");

    }
}
