using Application.HorseArtistApp.IHorseArtistServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistServices
{
    public class HorseArtistOrchestrationService : IHorseArtistOrchestrationService
    {
        private readonly IHorseArtistCrudService _hACrudService;
        private readonly IHorseArtistValidationService _hAValidationService;
        private readonly IHorseArtistInitializationService _hAInitializationService;
        private readonly IUnitOfWork _unitOfWork;

        public HorseArtistOrchestrationService(IHorseArtistCrudService hACrudService, IHorseArtistValidationService hAValidationService, IHorseArtistInitializationService horseArtistInitializationService ,IUnitOfWork unitOfWork)
        {
            _hACrudService = hACrudService;
            _hAValidationService = hAValidationService;
            _hAInitializationService = horseArtistInitializationService;
            _unitOfWork = unitOfWork;
        }


        public async Task<RuleResult> ValidateAndCreateHorseArtist(Guid userId)
        {
            var validationCheck = await _hAValidationService.UserIsHorseArtist(userId);

            if (!validationCheck.IsAllowed)
                return validationCheck;

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _hAInitializationService.LinkUserAndHorseArtistAsync(userId);


                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Horse Artist creation failed: {ex.Message}");
            }

        }

        public async Task<RuleResult> ApprovePendingArtistAsync (Guid artistId)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _hAInitializationService.ApprovePendingArtist(artistId);


                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Horse Artist creation failed: {ex.Message}");
            }


        }


    }
}
