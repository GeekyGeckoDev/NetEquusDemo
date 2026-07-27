using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainRules.BreedingRules
{
    public static class BreedingDelegateCheckAll
    {
        public delegate RuleResult HorseRule(Horse horse);
        public delegate RuleResult HorsePairRule(Horse dam, Horse sire);

        public static RuleResult CheckAll(Horse dam, Horse sire, params HorsePairRule[] rules)
        {
            foreach (var rule in rules)
            {
                var result = rule(dam, sire);
                if (!result.IsAllowed)
                    return result;
            }

            return RuleResult.Success();
        }
    }
}
