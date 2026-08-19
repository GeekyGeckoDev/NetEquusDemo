using Application.BreedApp.BreedStatsApp;
using Application.BreedApp.IBreedServices;
using Application.UnitOfWorks;
using Domain.DomainRules;
using Domain.Entities.Models.Breeds;
using Domain.Enums;
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
        private readonly IBreedGenMinMaxService _breedGenMin;

        public BreedOrchestrationService(IBreedCrudService breedCrudService, IBreedInitilizationService breedInitilizationService, IUnitOfWork unitOfWork, IBreedGenMinMaxService breedGenMinMaxService)
        {
            _breedCrudService = breedCrudService;
            _breedInitilizationService = breedInitilizationService;
            _unitOfWork = unitOfWork;
            _breedGenMin = breedGenMinMaxService;
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

                    await _breedGenMin.CreateBreedGenProfileAsync(breed.BreedID);
                  
                    
                });


                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Breed creation failed: {ex.Message}");
            }
        }

        public async Task<RuleResult> UpdateBreedAsync (Guid breedId)
        {
            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    await _breedInitilizationService.UpdateBreedFieldsAsync(breedId);
                });

                return RuleResult.Success();
            }
            catch (Exception ex)
            {
                return RuleResult.Fail($"Breed update failed: {ex.Message}");
            }
        }
    }
}
