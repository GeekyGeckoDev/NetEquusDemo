using Application.EconomyApp.HorseEconomyServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.EstateApp.IEstateServices.IEstateOrchestrationServices;
using Application.HorseApp;
using Application.SalesApp.HorseTrader;
using Application.UnitOfWorks;
using Domain.DomainRules;
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

        public HorseSaleManagerService (IHorseTraderSaleInitilizationService horseSaleInitilizationService, IHorseTraderSaleService horseSaleService, IHorseRelations horseRelations, IHorseEconomyService horseEconomyService, IUnitOfWork unitOfWork)
        {
            _horseSaleInitilizationService = horseSaleInitilizationService;
            _horseSaleService = horseSaleService;
            _horseRelations = horseRelations;
            _horseEconomyService = horseEconomyService;
            _unitOfWork = unitOfWork;

        }

        public async Task<RuleResult> FinalizeHorseTraderSaleAsync (HorseTraderRequest request)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var trade = await _horseSaleInitilizationService.InitilizationHorseTraderSale(request);

                    await _horseSaleService.CreateHorseTraderSaleAsync(trade);

                    if (request.Buyer.User.UserType == 0)
                    {
                        await _horseEconomyService.WithdrawAsync(
                            request.Buyer.Estate.EstateId,
                            request.Price);
                    }

                    if (request.Seller.User.UserType == 0)
                    {
                        await _horseEconomyService.DepositAsync(
                            request.Seller.Estate.EstateId,
                            request.Price);
                    }

                    await _horseRelations.UpdateBoardingAndOwnershipAsync(request.Seller.Horse.HorseId, request.Buyer.Estate.EstateId);


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
