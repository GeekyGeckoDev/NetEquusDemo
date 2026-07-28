using Application.EstateApp.EstateMappers;
using Domain.Entities.Models.Sales;
using Shared.Dtos.WrapperDto;
using Shared.Mappers.HorseMappers;
using Shared.Mappers.UserMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SalesApp.HorseTraderSales
{
    public class HorseTraderSaleInitilizationService : IHorseTraderSaleInitilizationService
    {


        public async Task<HorseTraderSale> InitilizationHorseTraderSale(HorseTraderSale traderRequest)
        {
            return new HorseTraderSale
            {
                Horse = traderRequest.Horse,
                SalesPrice = traderRequest.SalesPrice,
                
                BuyerEstate = traderRequest.BuyerEstate,

                SellerUser = traderRequest.SellerUser,
                SellerEstate = traderRequest.SellerEstate,

                DateOfSale = DateTime.UtcNow

            };


        }
    }
}
