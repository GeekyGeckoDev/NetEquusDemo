using Domain.DomainRules;
using Domain.Entities.Sales;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseSaleApp
{
    public interface IHorseSaleManagerService
    {
        Task FinalizeHorseTraderSaleAsync(HorseTraderSale request);

    }
}
