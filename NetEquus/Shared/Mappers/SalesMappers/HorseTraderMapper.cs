using Domain.Entities.Models.Sales;
using Shared.Dtos.SaleRequests;
using Shared.Dtos.WrapperDto;
using Shared.Mappers.EstateMappers;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.SalesMappers
{
    public class HorseTraderMapper
    {
        public static HorseTraderBuyer ToBuyerDto (HorseTraderSale sale)
        {
            return new HorseTraderBuyer
            {

                Estate = EstateMapper.ToDto(sale.BuyerEstate),
                User = UserMapper.UserMapper.ToDto(sale.BuyerUser)

            };
        }

        public static HorseTraderSeller ToSellerDto (HorseTraderSale sale)
        {
            return new HorseTraderSeller
            {
                Horse = HorseMapper.horseInfoDto(sale.Horse),
                User = UserMapper.UserMapper.ToDto(sale.SellerUser),
                Estate = EstateMapper.ToDto(sale.SellerEstate)

            };
        }

        public static HorseTraderSale ToBuyer (HorseTraderBuyer buyer)
        {
            return new HorseTraderSale
            {
                BuyerUser = UserMapper.UserMapper.ToUser(buyer.User),
                BuyerEstate = EstateMapper.ToEstate(buyer.Estate)

            };
        }

        public static HorseTraderSale ToSeller (HorseTraderSeller seller)
        {
            return new HorseTraderSale
            {
                Horse = HorseMapper.ToHorse(seller.Horse),

                SellerUser = UserMapper.UserMapper.ToUser(seller.User),

                SellerEstate = EstateMapper.ToEstate(seller.Estate)
            };
        }

       
    }
}
