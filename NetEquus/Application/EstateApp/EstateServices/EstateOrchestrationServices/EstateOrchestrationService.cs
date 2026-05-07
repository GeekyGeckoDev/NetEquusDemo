using Application.EstateApp.EstateDtos;
using Application.EstateApp.EstateMappers;
using Application.EstateApp.IEstateServices;
using Application.EstateApp.IEstateServices.IEstateCrudServices;
using Application.EstateApp.IEstateServices.IEstateOrchestrationServices;
using Application.OwnershipApp.IOwnershipServices;
using Application.SharedApp.IOwnershipServices;
using Application.SharedApp.OwnershipDtos;
using Application.SharedApp.OwnershipMappers;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Shared.Dtos.UserDtos;

namespace Application.EstateApp.EstateServices.EstateOrchestrationServices
{
    public class EstateOrchestrationService : IEstateOrchestrationService
    {
        private readonly IClientEstateCrudService _clientEstateCrudService;
        private readonly IEstateInitilizationService _estateInitilizationService;
        private readonly IEstateOrchestrationValidationService _orchestrationValidationService;
        private readonly IEstateGetService _estateGetService;
        private readonly IEstateOwnershipOrchestrationService _orchestrationOwnershipService;
        private readonly IUnitOfWork _unitOfWork;

        public EstateOrchestrationService(IClientEstateCrudService clientEstateCrudService, IEstateInitilizationService estateInitilizationService, IEstateOrchestrationValidationService orchestrationValidationService, IEstateGetService estateGetService, IEstateOwnershipOrchestrationService orchestrationOwnershipService, IUnitOfWork unitOfWork)
        {
            _clientEstateCrudService = clientEstateCrudService;
            _estateInitilizationService = estateInitilizationService;
            _orchestrationValidationService = orchestrationValidationService;
            _estateGetService = estateGetService;
            _orchestrationOwnershipService = orchestrationOwnershipService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> CreateEstateWithOwnership(Guid userId, EstateCreationDto estateCreationDto)
        {
            var validationCheck = await _orchestrationValidationService.FinalValidationAsync(userId, estateCreationDto);

            if (!validationCheck.IsAllowed)
                return validationCheck;

            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _estateInitilizationService.EstateInitializationAsync(estateCreationDto);

                    var estate = EstateMapper.ToCreationEstate(estateCreationDto);
                    await _clientEstateCrudService.CreateEstateAsync(estate);

                    await _orchestrationOwnershipService.LinkUserToEstateAsync(userId, estate.EstateId, true);
                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Estate creation failed: {ex.Message}");
            }
        }
        public async Task<EstateDto> GetConvertEstateAsync (Guid estateId)
        {
            var Getestate = await _estateGetService.GetEstateByIdAsync(estateId);

            var estate = EstateMapper.ToDto(Getestate);

            return estate;
        }

    }
}
