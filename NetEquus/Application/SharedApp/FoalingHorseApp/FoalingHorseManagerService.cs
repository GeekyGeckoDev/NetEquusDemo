using Application.BoardingApp.IBoardingServices;
using Application.FoalingApp.IFoalingServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.UnitOfWorks;
using Application.UserApp.IUserServices.IUserCrudServices;
using Domain.DomainRules;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SharedApp.FoalingHorseApp
{
    public class FoalingHorseManagerService : IFoalingHorseManagerService
    {
        private readonly IFoalingCrudService _foalingService;

        private readonly IHorseInitilizationService _horseInitilizationService;

        private readonly IHorseOwnershipOrchestrationService _horseOwnershipOrchestrationService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IHorseCrudService _horseCrudService;

        private readonly IBoardingOrchestrationService _boardingOrchestrationService;
        private readonly IBoardingGetService _boardingGetService;

        private readonly IHorseGetService _horseGetService;

        private readonly IUserGetService _userGetService;

        private readonly IHorseOwnershipGetService _horseOwnershipGetService;

        private readonly IFoalingValidationService _foalingValidationService;

        public FoalingHorseManagerService(IFoalingCrudService foalingService, IHorseInitilizationService horseInitilizationService, IHorseOwnershipOrchestrationService horseOwnershipOrchestration, IUnitOfWork unitOfWork, IHorseCrudService horseCrudService, IBoardingOrchestrationService boardingOrchestrationService, IHorseGetService horseGetService, IHorseOwnershipGetService horseOwnershipGetService, IBoardingGetService boardingGetService, IUserGetService userGetService, IFoalingValidationService foalingValidationService)
        {
            _foalingService = foalingService;
            _horseInitilizationService = horseInitilizationService;
            _horseOwnershipOrchestrationService = horseOwnershipOrchestration;
            _unitOfWork = unitOfWork;
            _horseCrudService = horseCrudService;
            _boardingOrchestrationService= boardingOrchestrationService;
            _horseGetService = horseGetService;
            _horseOwnershipGetService = horseOwnershipGetService;
            _boardingOrchestrationService = boardingOrchestrationService;
            _boardingGetService = boardingGetService;
            _userGetService = userGetService;
            _foalingValidationService = foalingValidationService;

        }

        public async Task<RuleResult> CreatePendingFoalingAsync(Guid userId, Guid dam, Guid sire)
        {

            var mare = await _horseGetService.GetHorseByIdAsync(dam);

            var stallion = await _horseGetService.GetHorseByIdAsync(sire);

            var compatible = await _foalingValidationService.CheckFoalingRules(mare, stallion);

            if (!compatible.IsAllowed)
            {
                return RuleResult.Fail("Not compatible");
            }

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {

                    var mareOwner = await _horseOwnershipGetService
                        .GetOwnershipByHorseIdAsync(mare.GuidHorseId);


                    var estate = await _boardingGetService.GetBoardingByHorseIdAsync(mare.GuidHorseId);

                    var breeder = await _userGetService
                        .GetUserByIdAsync(mareOwner.UserId);

                    if (userId != breeder.UserId)
                    {
                        throw new Exception("Users can only breed mares they own");
                    }

                    Random rnd = new Random();

                    int FoalingDays = rnd.Next(17, 22);


                    var foaling = new Foaling
                    {
                        BreederId = breeder.UserId,
                        DateBred = GameDate.Today(),
                        DueDate = GameDate.Today().AddDays(FoalingDays),
                        EquineEstateId = estate.BoardingEstateId,
                        DamId = mare.GuidHorseId,
                        SireId = stallion.GuidHorseId,
                        Status = FoalingStatus.InFoal,
                        BirthTime = (GameWindow)rnd.Next(0, 4)

                    };

                    await _foalingService.CreateFoalingAsync(foaling);

                });

                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail($"Horse creation failed; {ex.Message}");
            }




        }

        // Old method.
        //public async Task<RuleResult> CreateHorseOwnershipBoardingFoalingAsync (Guid userId, Guid dam, Guid sire)
        //{

        //    var mare = await _horseGetService.GetHorseByIdAsync(dam);

        //    var stallion = await _horseGetService.GetHorseByIdAsync(sire);

        //    var compatible = await _foalingValidationService.CheckFoalingRules(mare, stallion);

        //    if(!compatible.IsAllowed)
        //    {
        //        return RuleResult.Fail("Not compatible");
        //    }

        //    try
        //    {
        //        await _unitOfWork.ExecuteAsync(async () =>
        //        {


        //            var foal = await _horseInitilizationService.FoalGenerationInitilizationAsync(mare, stallion);


                    

        //            await _horseCrudService.CreateHorseAsync(foal);

        //                var mareOwner = await _horseOwnershipGetService
        //                    .GetOwnershipByHorseIdAsync(mare.GuidHorseId);

        //            var breeder = await _userGetService
        //                .GetUserByIdAsync(mareOwner.UserId);

        //            if (userId != breeder.UserId)
        //            {
        //                throw new Exception("Users can only breed mares they own");
        //            }

        //            await _horseOwnershipOrchestrationService.CreateLinkUserToHorse(breeder.UserId, foal.GuidHorseId);

        //            var estate = await _boardingGetService.GetBoardingByHorseIdAsync (mare.GuidHorseId);

                    


        //            await _boardingOrchestrationService.CreateLinkEstateToHorse(estate.BoardingEstateId, foal.GuidHorseId);

        //                    var foaling = new Foaling
        //                    {
        //                        BreederId = breeder.UserId,
        //                        FoalingDate = foal.BirthDate,
        //                        EquineEstateId = estate.BoardingEstateId,
        //                        FoalId = foal.GuidHorseId,
        //                        DamId = mare.GuidHorseId,
        //                        SireId = stallion.GuidHorseId

        //                    };

        //            await _foalingService.CreateFoalingAsync(foaling);

        //                });

        //        return RuleResult.Success();
        //    }

        //    catch (Exception ex)
        //    {
        //        return RuleResult.Fail($"Horse creation failed; {ex.Message}");
        //    }


        //}
    }


}
