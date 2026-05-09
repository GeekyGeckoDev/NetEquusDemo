using Application.BreedApp.IBreedServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Shared.Dtos.BreedDtos;
using Shared.Mappers.BreedMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedServices
{
    public class BreedOrchestrationService : IBreedOrchestrationService
    {
        private readonly IBreedCrudService _breedCrudService;
        private readonly IBreedInitilizationService _breedInitilizationService;
        private readonly IUnitOfWork _unitOfWork;

        public BreedOrchestrationService(IBreedCrudService breedCrudService, IBreedInitilizationService breedInitilizationService, IUnitOfWork unitOfWork)
        {
            _breedCrudService = breedCrudService;
            _breedInitilizationService = breedInitilizationService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RuleResult> CreateBreedAsync (BreedDto dto)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _breedInitilizationService.BreedInitilizationAsync(dto);

                    var breed = BreedMapper.ToEntity(dto);
                    await _breedCrudService.CreateBreedAsync(breed);
                });


                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Breed creation failed: {ex.Message}");
            }
        }
    }
}
