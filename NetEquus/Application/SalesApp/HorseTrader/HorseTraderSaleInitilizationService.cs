using Application.EstateApp.EstateMappers;
using Domain.Entities.Models.Sales;
using Shared.Dtos.WrapperDto;
using Shared.Mappers.HorseMappers;
using Shared.Mappers.UserMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTrader
{
    public class HorseTraderSaleInitilizationService : IHorseTraderSaleInitilizationService
    {

        
        public async Task<HorseTraderSale> InitilizationHorseTraderSale (HorseTraderRequest traderRequest)
        {
            return new HorseTraderSale
            {
                Horse = HorseMapper.ToHorse(traderRequest.Seller.Horse),
                SalesPrice = traderRequest.Price,

                BuyerUser = UserMapper.ToUser(traderRequest.Buyer.User),
                BuyerEstate = EstateMapper.ToEstate(traderRequest.Buyer.Estate),

                SellerUser = UserMapper.ToUser(traderRequest.Seller.User),
                SellerEstate = EstateMapper.ToEstate(traderRequest.Seller.Estate),

                DateOfSale = DateTime.UtcNow

            };


        }
    }
}
