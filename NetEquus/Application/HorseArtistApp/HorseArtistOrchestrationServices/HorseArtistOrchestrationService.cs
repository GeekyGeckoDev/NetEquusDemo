using Application.HorseArtistApp.IHorseArtistServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistOrchestrationServices
{
    public class HorseArtistOrchestrationService
    {
        private readonly IHorseArtistCrudService _hACrudService;
        private readonly IHorseArtistValidationService _hAValidationService;
        private readonly IUnitOfWork _unitOfWork;

        public HorseArtistOrchestrationService(IHorseArtistCrudService hACrudService, IHorseArtistValidationService hAValidationService, IUnitOfWork unitOfWork)
        {
            _hACrudService = hACrudService;
            _hAValidationService = hAValidationService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> ValidateAndCreateHorseArtist(Guid userId, HorseArtist horseArtist)
        {
            var validationCheck = await _hAValidationService.UserIsHorseArtist(userId);

            if (!validationCheck.IsAllowed)
                return validationCheck;

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _hACrudService.CreateHorseArtistAsync(horseArtist);


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
