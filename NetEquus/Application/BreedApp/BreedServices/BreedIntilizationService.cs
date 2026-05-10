using Application.BreedApp.IBreedServices;
using Domain.Entities.Models.Breeds;
using Shared.Dtos.BreedDtos;
using Shared.Mappers.BreedMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedServices
{
    public class BreedIntilizationService : IBreedInitilizationService
    {

        private readonly IBreedGetService _breedGetService;

        public BreedIntilizationService(IBreedGetService breedGetService)
        {
            _breedGetService = breedGetService;
        }
    
        public async Task  BreedInitilizationAsync (BreedDto dto)
        {
            var breed = new Breed
            {
                BreedName = dto.BreedName,
                BreedAbbreviation = dto.BreedAbbreviation,
                MinHeight = dto.MinHeight,
                MaxHeight = dto.MaxHeight,
            };
        }

        public async Task UpdateBreedFieldsAsync(Guid breedId)
        {
            var breed = await _breedGetService.GetBreedByIdAsync(breedId);

            if (breed == null)
                throw new Exception("Breed not found");

            var dto =  BreedMapper.ToInfoDto(breed);

            breed.BreedName = dto.BreedName;
            breed.BreedAbbreviation = dto.BreedAbbreviation;
            breed.MinHeight = dto.MinHeight;
            breed.MaxHeight = dto.MaxHeight;
        }

    }
}
