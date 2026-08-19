using Application.BoardingApp.IBoardingServices;
using Application.HorseApp.HorseStatsApp.GenerateHorseStats;
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

        private readonly IAttributeOrchestration _attributeOrchestration;

        public HorseOrchestrationService(IHorseInitilizationService horseInitilizationService, IHorseOwnershipOrchestrationService horseOwnershipOrchestrationService ,IUnitOfWork unitOfWork, IHorseCrudService horseCrudService, 
            IBoardingOrchestrationService boardingOrchestrationService, IAttributeOrchestration attributeOrchestration)
        {
            _horseInitilizationService = horseInitilizationService;
            _horseOwnershipOrchestrationService = horseOwnershipOrchestrationService;
            _unitOfWork = unitOfWork;
            _horseCrudService = horseCrudService;
            _boardingOrchestrationService = boardingOrchestrationService;
            _attributeOrchestration = attributeOrchestration;
       
        }

        public async Task<RuleResult> GenerateHorseWithOwnershipAsync ()
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var Dto = await _horseInitilizationService.HorseGenerationInitilizationAsync();

                    var horse = HorseMapper.ToNewHorse(Dto);


                    await _horseCrudService.CreateHorseAsync(horse);

                    await _attributeOrchestration.GenerateCreateAttributesAsync(horse);

                    // Mayas ID
                    Guid systemNpcUserId = Guid.Parse("DAC49776-72D9-49FD-8D1F-08DEFABB5062");

                    await _horseOwnershipOrchestrationService.CreateLinkUserToHorseAsync(systemNpcUserId, horse.GuidHorseId);

                    Guid systemEstateId = Guid.Parse("B34F5477-D6D4-46C9-3A3F-08DEFABC694E");

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
