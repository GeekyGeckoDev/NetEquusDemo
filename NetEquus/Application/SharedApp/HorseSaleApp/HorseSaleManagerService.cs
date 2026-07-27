using Application.EconomyApp.HorseEconomyServices;
using Application.HorseApp;
using Application.SalesApp.HorseTraderSales;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Sales;
using Shared.Dtos.WrapperDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.HorseSaleApp
{
    public class HorseSaleManagerService : IHorseSaleManagerService
    {
        private readonly IHorseTraderSaleInitilizationService _horseSaleInitilizationService;
        private readonly IHorseTraderSaleService _horseSaleService;
        private readonly IHorseRelations _horseRelations;
        private readonly IHorseEconomyService _horseEconomyService;
        private readonly IUnitOfWork _unitOfWork;

        public HorseSaleManagerService(IHorseTraderSaleInitilizationService horseSaleInitilizationService, IHorseTraderSaleService horseSaleService, IHorseRelations horseRelations, IHorseEconomyService horseEconomyService, IUnitOfWork unitOfWork)
        {
            _horseSaleInitilizationService = horseSaleInitilizationService;
            _horseSaleService = horseSaleService;
            _horseRelations = horseRelations;
            _horseEconomyService = horseEconomyService;
            _unitOfWork = unitOfWork;

        }

        public async Task FinalizeHorseTraderSaleAsync(HorseTraderSale request)
        {
       

                    await _horseSaleService.CreateHorseTraderSaleAsync(request);

                    if (request.BuyerUser.UserTypeEnum == 0)
                    {
                        await _horseEconomyService.WithdrawAsync(
                            request.BuyerEstate.EstateId,
                            request.SalesPrice);
                    }

                    if (request.SellerUser.UserTypeEnum == 0)
                    {
                        await _horseEconomyService.DepositAsync(
                            request.SellerEstate.EstateId,
                            request.SalesPrice);
                    }

                    await _horseRelations.UpdateBoardingAndOwnershipAsync(request.Horse.GuidHorseId, request.BuyerEstate.EstateId);


               
      

        }
    }
}
