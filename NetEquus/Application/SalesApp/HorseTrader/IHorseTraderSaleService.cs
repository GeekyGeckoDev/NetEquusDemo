using Domain.Entities.Models.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTrader
{
    public interface IHorseTraderSaleService
    {
        Task CreateHorseTraderSaleAsync(HorseTraderSale sale);
    }
}
