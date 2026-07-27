using Domain.Entities.Sales;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTraderSales
{
    public interface IHorseTraderSaleInitilizationService
    {
        Task<HorseTraderSale> InitilizationHorseTraderSale(HorseTraderSale traderRequest);
    }
}
