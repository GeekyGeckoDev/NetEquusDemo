using Domain.DomainRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseSaleApp
{
    public interface IHorseTraderManagerService
    {
        Task<RuleResult> BuyHorseAsync(Guid userId, Guid horseId);

        Task<RuleResult> SellHorseAsync(Guid userId, Guid horseId);
    }
}
