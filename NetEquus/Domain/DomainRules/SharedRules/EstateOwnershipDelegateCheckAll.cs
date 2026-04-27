using Domain.DomainRules;
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DomainRules.UserRules.EmailDelegateCheckAll;

namespace Domain.DomainRules.SharedRules
{
    public class EstateOwnershipDelegateCheckAll
    {
        public delegate RuleResult EstateOwnershipRule (EstateOwnership estateOwner);

        public static RuleResult CheckAll (EstateOwnership estateOwnership, params EstateOwnershipRule[] rules)
        {
            foreach (var rule in rules)
            {
                var result = rule(estateOwnership);
                if (!result.IsAllowed)
                    return result;
            }

            return RuleResult.Success();
        }

    }
}