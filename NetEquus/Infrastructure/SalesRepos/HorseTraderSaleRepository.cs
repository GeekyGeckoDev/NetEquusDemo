using Application.SalesApp.HorseTraderSales;
using Domain.Entities.Models.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.SalesRepos
{
    public class HorseTraderSaleRepository : IHorseTraderSaleRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseTraderSaleRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseTraderSale(HorseTraderSale sale)
        {
            await _context.HorseTraderSales.AddAsync(sale);
        }
    }
}
