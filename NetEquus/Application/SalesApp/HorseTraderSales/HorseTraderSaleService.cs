using Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTraderSales
{
    public class HorseTraderSaleService : IHorseTraderSaleService
    {
        private readonly IHorseTraderSaleRepository _horseTraderSaleRepository;

        public HorseTraderSaleService(IHorseTraderSaleRepository horseTraderSaleRepository)
        {
            _horseTraderSaleRepository = horseTraderSaleRepository;
        }

        public async Task CreateHorseTraderSaleAsync(HorseTraderSale sale)
        {
            await _horseTraderSaleRepository.CreateHorseTraderSale(sale);
        }
    }
}
