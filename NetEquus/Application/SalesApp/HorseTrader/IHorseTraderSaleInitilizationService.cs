using Domain.Entities.Models.Sales;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTrader
{
    public interface IHorseTraderSaleInitilizationService
    {
        Task<HorseTraderSale> InitilizationHorseTraderSale(HorseTraderRequest traderRequest);
    }
}
