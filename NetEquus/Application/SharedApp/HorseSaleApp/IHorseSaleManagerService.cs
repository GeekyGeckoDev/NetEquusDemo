using Domain.DomainRules;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseSaleApp
{
    public interface IHorseSaleManagerService
    {
        Task<RuleResult> FinalizeHorseTraderSaleAsync(HorseTraderRequest request);

    }
}
