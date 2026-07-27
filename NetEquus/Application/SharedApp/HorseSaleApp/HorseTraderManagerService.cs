using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.EstateOwnershipApp.IEstateOwnershipServices;
using Application.SalesApp.HorseTraderSales;
using Application.UnitOfWorks;
using Application.UserApp.IUserServices.IUserCrudServices;
using Application.UserApp.NpcServices;
using Domain.DomainRules;
using Domain.Entities.Models.Users;
using Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.SharedApp.HorseSaleApp
{
    public class HorseTraderManagerService : IHorseTraderManagerService
    {
        private readonly IUserGetService _userGetService;
        private readonly INpcManagerService _npcManagerService;
        private readonly IEstateGetService _estateGetService;
        private readonly IHorseGetService _horseGetService;
        private readonly IHorseSaleManagerService _horseSaleManagerService;
        private readonly IEstateOwnershipGetService _estateOwnershipGetService;
        private readonly IUnitOfWork _unitOfWork;

        public HorseTraderManagerService(IUserGetService userGetService, INpcManagerService npcManagerService, IEstateGetService estateGetService, IHorseGetService horseGetService, IHorseSaleManagerService horseSaleManagerService, IUnitOfWork unitOfWork, IEstateOwnershipGetService estateOwnershipGetService)
        {
            _userGetService = userGetService;
            _npcManagerService = npcManagerService;
            _estateGetService = estateGetService;
            _horseGetService = horseGetService;
            _horseSaleManagerService = horseSaleManagerService;
            _estateOwnershipGetService = estateOwnershipGetService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> BuyHorseAsync (Guid userId, Guid horseId)
        {

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var user = await _userGetService.GetUserByIdAsync(userId);

                    var userOwnership = await _estateOwnershipGetService.GetEstateOwnershipByUserIdAsync(userId);

                    var userEstate = await _estateGetService.GetEstateByIdAsync((Guid)userOwnership.EquineEstateId);

                    var traderOwnership = await _npcManagerService.GetHorseTraderDataAsync();

                    var traderEstate = await _estateGetService.GetEstateByIdAsync((Guid)traderOwnership.EquineEstateId);

                    var trader = await _userGetService.GetUserByIdAsync(traderOwnership.UserId);

                    var horse = await _horseGetService.GetHorseByIdAsync(horseId);

                    var trade = new HorseTraderSale
                    {
                        Horse = horse,
                        SalesPrice = horse.EquinsValue,
                        BuyerEstate = userEstate,
                        BuyerUser = user,

                        SellerUser = trader,
                        SellerEstate = traderEstate,

                    };



                    await _horseSaleManagerService.FinalizeHorseTraderSaleAsync(trade);
                });

                return RuleResult.Success();
            }
                catch (Exception ex)
            {
                return RuleResult.Fail(ex.Message);
            }


        }

        public async Task<RuleResult> SellHorseAsync (Guid userId, Guid horseId)
        {

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var user = await _userGetService.GetUserByIdAsync(userId);

                    var userOwnership = await _estateOwnershipGetService.GetEstateOwnershipByUserIdAsync(userId);

                    var userEstate = await _estateGetService.GetEstateByIdAsync((Guid)userOwnership.EquineEstateId);

                    var traderOwnership = await _npcManagerService.GetHorseTraderDataAsync();

                    var traderEstate = await _estateGetService.GetEstateByIdAsync((Guid)traderOwnership.EquineEstateId);

                    var trader = await _userGetService.GetUserByIdAsync(traderOwnership.UserId);

                    var horse = await _horseGetService.GetHorseByIdAsync(horseId);

                    var trade = new HorseTraderSale
                    {
                        Horse = horse,
                        SalesPrice = CalculateHorsePrize.CalculateHorseTraderPrize(horse.EquinsValue),
                        BuyerEstate = traderEstate,
                        BuyerUser = trader,

                        SellerUser = user,
                        SellerEstate = userEstate,

                    };



                    await _horseSaleManagerService.FinalizeHorseTraderSaleAsync(trade);
                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail(ex.Message);
            }

        }
    }


}
