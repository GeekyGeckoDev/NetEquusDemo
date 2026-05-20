using Application.BoardingApp.IBoardingServices;
using Application.FoalingApp.IFoalingServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.UnitOfWorks;
using Application.UserApp.IUserServices.IUserCrudServices;
using Domain.DomainRules;
using Domain.Entities.Models.Horses;
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

        public FoalingHorseManagerService(IFoalingCrudService foalingService, IHorseInitilizationService horseInitilizationService, IHorseOwnershipOrchestrationService horseOwnershipOrchestration, IUnitOfWork unitOfWork, IHorseCrudService horseCrudService, IBoardingOrchestrationService boardingOrchestrationService, IHorseGetService horseGetService, IHorseOwnershipGetService horseOwnershipGetService, IBoardingGetService boardingGetService, IUserGetService userGetService)
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

        }

        public async Task<RuleResult> CreateHorseOwnershipBoardingFoalingAsync (Guid dam, Guid sire)
        {

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var mare = await _horseGetService.GetHorseByIdAsync (dam);

                    var stallion = await _horseGetService.GetHorseByIdAsync(sire);

                    var foal = await _horseInitilizationService.FoalGenerationInitilizationAsync(mare, stallion);

                    await _horseCrudService.CreateHorseAsync(foal);

                        var mareOwner = await _horseOwnershipGetService
                            .GetOwnershipByHorseIdAsync(mare.GuidHorseId);

                    var breeder = await _userGetService
                        .GetUserByIdAsync(mareOwner.UserId);


                    await _horseOwnershipOrchestrationService.CreateLinkUserToHorse(breeder.UserId, foal.GuidHorseId);

                    var estate = await _boardingGetService.GetBoardingByHorseIdAsync (mare.GuidHorseId);

                    


                    await _boardingOrchestrationService.CreateLinkEstateToHorse(estate.BoardingEstateId, foal.GuidHorseId);

                            var foaling = new Foaling
                            {
                                BreederId = breeder.UserId,
                                FoalingDate = foal.BirthDate,
                                EquineEstateId = estate.BoardingEstateId,
                                FoalId = foal.GuidHorseId,
                                DamId = mare.GuidHorseId,
                                SireId = stallion.GuidHorseId

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
    }


}
