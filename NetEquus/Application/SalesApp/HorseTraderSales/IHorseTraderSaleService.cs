using Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTraderSales
{
    public interface IHorseTraderSaleService
    {
        Task CreateHorseTraderSaleAsync(HorseTraderSale sale);
    }
}
