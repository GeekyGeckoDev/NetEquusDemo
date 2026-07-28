using Application.BoardingApp.IBoardingServices;
using Application.FoalingApp.IFoalingServices;
using Application.HorseApp.IHorseServices;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Domain.Entities.Models.Horses;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.FoalingServices
{
    public class HorseBirthManager : IHorseBirthManager
    {
        private readonly IHorseInitilizationService _horseInitilizationService;
        private readonly IHorseCrudService _horseCrudService;
        private readonly IHorseOwnershipOrchestrationService _horseOwnershipOrchestrationService;
        private readonly IBoardingOrchestrationService _boardingOrchestrationService;

        public HorseBirthManager(IHorseInitilizationService horseInitilizationService, IHorseCrudService horseCrudService, IHorseOwnershipOrchestrationService horseOwnershipOrchestrationService, IBoardingOrchestrationService boardingOrchestrationService)
        {
            _horseInitilizationService = horseInitilizationService;
            _horseCrudService = horseCrudService;
            _horseOwnershipOrchestrationService = horseOwnershipOrchestrationService;

            _boardingOrchestrationService = boardingOrchestrationService;
        }
        public async Task CreateFoalFromFoaling (Foaling foaling)
        {
            var foal = await _horseInitilizationService.FoalGenerationInitilizationAsync(foaling);

            await _horseCrudService.CreateHorseAsync(foal);

            foaling.Status = Domain.Enums.FoalingStatus.Foaled;

            foaling.FoalId = foal.GuidHorseId;

            foaling.Dam.BreedingCoolDown = GameDate.Today().AddDays(10);

            await _horseOwnershipOrchestrationService.CreateLinkUserToHorseAsync(foaling.BreederId, foal.GuidHorseId);

            await _boardingOrchestrationService.CreateLinkEstateToHorse(foaling.EquineEstateId, foal.GuidHorseId);
        }

    }
}
