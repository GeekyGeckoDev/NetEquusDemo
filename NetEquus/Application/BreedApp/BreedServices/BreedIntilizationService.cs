using Application.BreedApp.IBreedServices;
using Domain.Entities.Models.Breeds;
using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BreedApp.BreedServices
{
    public class BreedIntilizationService : IBreedInitilizationService
    {
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
    }
}
