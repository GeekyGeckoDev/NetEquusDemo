using Application.BoardingApp.IBoardingServices;
using Application.HorseApp.IHorseServices;
using Application.HorseApp.UpdateHorse;
using Application.OwnershipApp.HorseOwnershipApp.IHorseOwnershipServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Shared.Mappers.HorseMappers;


namespace Application.HorseApp.HorseServices
{
    public class HorseOrchestrationService : IHorseOrchestrationService
    {
        private readonly IHorseInitilizationService _horseInitilizationService;

        private readonly IHorseOwnershipOrchestrationService _horseOwnershipOrchestrationService;

        private readonly IUnitOfWork _unitOfWork;


        private readonly IHorseCrudService _horseCrudService;

        private readonly IBoardingOrchestrationService _boardingOrchestrationService;

        public HorseOrchestrationService(IHorseInitilizationService horseInitilizationService, IHorseOwnershipOrchestrationService horseOwnershipOrchestrationService ,IUnitOfWork unitOfWork, IHorseCrudService horseCrudService, IBoardingOrchestrationService boardingOrchestrationService)
        {
            _horseInitilizationService = horseInitilizationService;
            _horseOwnershipOrchestrationService = horseOwnershipOrchestrationService;
            _unitOfWork = unitOfWork;
            _horseCrudService = horseCrudService;
            _boardingOrchestrationService = boardingOrchestrationService;
        }

        public async Task<RuleResult> GenerateHorseWithOwnershipAsync ()
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var Dto = await _horseInitilizationService.HorseGenerationInitilizationAsync();

                    var horse = HorseGenerationMapper.ToNewHorse(Dto);


                    await _horseCrudService.CreateHorseAsync(horse);

                    // Mayas ID
                    Guid systemNpcUserId = Guid.Parse("E32ED213-FEB6-420B-B9DF-08DEAEA7F6E7");

                    await _horseOwnershipOrchestrationService.CreateLinkUserToHorse(systemNpcUserId, horse.GuidHorseId);

                    Guid systemEstateId = Guid.Parse("34AF2A74-27A4-46B1-7A13-08DEB029BE46");

                    await _boardingOrchestrationService.CreateLinkEstateToHorse(systemEstateId, horse.GuidHorseId);

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
